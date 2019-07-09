using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Drivers;
using Erdem.TodoList.Models;
using Erdem.TodoList.Services;
using Orchard.ContentManagement;
using Orchard;
using Orchard.Alias;


namespace Erdem.TodoList.Drivers {
    public class TaskDriver : ContentPartDriver<TaskPart> {

        private readonly ITaskService _featuredProductService;

        public TaskDriver(ITaskService featuredProductService) {
            _featuredProductService = featuredProductService;
        }

        protected override DriverResult Display(TaskPart part,
         string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_Task", () => {
                return shapeHelper.Parts_Task(IsOnFeaturedProductPage:
                  _featuredProductService.IsOnFeaturedProductPage());
            });
        }

        protected override DriverResult Editor(TaskPart part,
         dynamic shapeHelper) {
            return ContentShape("Parts_Task_Edit",
              () => shapeHelper.EditorTemplate(
                TemplateName: "Parts/Task",
                Model: part,
                Prefix: Prefix));
        }

        protected override DriverResult Editor(TaskPart part,
         IUpdateModel updater, dynamic shapeHelper) {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

    }
}