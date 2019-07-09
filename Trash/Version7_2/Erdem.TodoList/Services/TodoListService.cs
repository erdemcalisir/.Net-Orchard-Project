using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard;
using Orchard.ContentManagement;
using Erdem.TodoList.Models;

namespace Erdem.TodoList.Services {
    public class TodoListService : ITodoListService{

        private readonly IWorkContextAccessor _workContextAccessor;
        private readonly IContentManager _contentManager;
        public IEnumerable<TodoListItem> Items { get { return ItemsInternal.AsReadOnly(); } }

        private HttpContextBase HttpContext {
            get { return _workContextAccessor.GetContext().HttpContext; }
        }

        private List<TodoListItem> ItemsInternal {
            get {
                var items = (List<TodoListItem>)HttpContext.Session["TodoList"];

                if (items == null) {
                    items = new List<TodoListItem>();
                    HttpContext.Session["TodoList"] = items;
                }

                return items;
            }
        }

        public TodoListService(IWorkContextAccessor workContextAccessor, IContentManager contentManager) {
            _workContextAccessor = workContextAccessor;
            _contentManager = contentManager;
        }

        public void Add(int taskId, string taskTitle, string taskContent, bool taskStatu) {
            var item = Items.SingleOrDefault(x => x.TaskId == taskId);
            item = Items.SingleOrDefault(x => x.TaskTitle == taskTitle);
            item = Items.SingleOrDefault(x => x.TaskContent == taskContent);
            item = Items.SingleOrDefault(x => x.TaskStatu == taskStatu);

                item = new TodoListItem( taskId,  taskTitle,  taskContent, taskStatu);
                ItemsInternal.Add(item);
            
            //else {
            //    item.Quantity += quantity;
            //}
        }

        public void Remove(int taskId) {
            var item = Items.SingleOrDefault(x => x.TaskId == taskId);

            if (item == null)
                return;

            ItemsInternal.Remove(item);
        }

        public TaskPart GetProduct(int taskId) {
            return _contentManager.Get<TaskPart>(taskId);
        }


        private void Clear() {
            ItemsInternal.Clear();
            
        }

    }
}