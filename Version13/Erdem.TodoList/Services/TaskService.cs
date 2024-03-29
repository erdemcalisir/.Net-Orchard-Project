﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard;
using Orchard.Alias;
using Orchard.ContentManagement;

namespace Erdem.TodoList.Services {
    public class TaskService : ITaskService {

        private readonly IContentManager _contentManager;
        private readonly IWorkContextAccessor _workContextAccessor;
        private readonly IAliasService _aliasService;

        private IContent _currentContent = null;
        private IContent CurrentContent {
            get {
                if (_currentContent == null) {
                    var itemRoute = _aliasService.Get(_workContextAccessor.GetContext()
                      .HttpContext.Request.AppRelativeCurrentExecutionFilePath
                      .Substring(1).Trim('/'));

                    _currentContent = _contentManager.Get(Convert.ToInt32(itemRoute["Id"]));
                }
                return _currentContent;
            }
        }

        public TaskService(IContentManager contentManager,
          IWorkContextAccessor workContextAccessor,
          IAliasService aliasService) {
            _contentManager = contentManager;
            _workContextAccessor = workContextAccessor;
            _aliasService = aliasService;
        }

        public bool IsOnFeaturedProductPage() {
            bool isOnFeaturedProductPage = false;

            var itemTypeName = CurrentContent.ContentItem.TypeDefinition.Name;

            if (itemTypeName.Equals("Work",
              StringComparison.InvariantCultureIgnoreCase)) {
                var dynamicContentItem = (dynamic)CurrentContent.ContentItem;
                var itemProductId = dynamicContentItem.Work.WorkId.Value;
                if (itemProductId.Equals("example1",
                  StringComparison.InvariantCulture)) {
                    isOnFeaturedProductPage = true;
                }
            }

            return isOnFeaturedProductPage;
        }

    }
}