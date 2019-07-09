using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Orchard;
using Orchard.ContentManagement;
using Orchard.Data;
using Erdem.TodoList.Models;

namespace Erdem.TodoList.Services {
    public class TaskListCart : ITaskListCart {

        private readonly IWorkContextAccessor _workContextAccessor;
        private readonly IContentManager _contentManager;

        public IEnumerable<TaskListCartItem> Items { get { return ItemsInternal.AsReadOnly(); } }

        private HttpContextBase HttpContext {
            get { return _workContextAccessor.GetContext().HttpContext; }
        }
        private List<TaskListCartItem> ItemsInternal {
            get {
                var items = (List<TaskListCartItem>)HttpContext.Session["TaskListCart"];

                if (items == null) {
                    items = new List<TaskListCartItem>();
                    HttpContext.Session["TaskListCart"] = items;
                }

                return items;
            }
        }
        public TaskListCart(IWorkContextAccessor workContextAccessor, IContentManager contentManager) {
            _workContextAccessor = workContextAccessor;
            _contentManager = contentManager;
        }
        public void Add(int taskId) {
            var item = Items.SingleOrDefault(x => x.TaskId == taskId);

            if (item == null) {
                item = new TaskListCartItem(taskId);
                ItemsInternal.Add(item);
            }
            else {
            }

        }
        public void Remove(int taskId) {
            var item = Items.SingleOrDefault(x => x.TaskId == taskId);

            if (item == null)
                return;

            ItemsInternal.Remove(item);
        }
        
        //public TaskPart GetProduct(int taskId) {
        //   return _contentManager.Get<TaskPart>(taskId);
        //}

        public IEnumerable<TaskQuantity> GetProducts() {
            // Get a list of all product IDs from the shopping cart
            var ids = Items.Select(x => x.TaskId).ToList();

            // Load all product parts by the list of IDs
            var taskParts = _contentManager.GetMany<TaskPart>(ids, VersionOptions.Latest, QueryHints.Empty).ToArray();

            // Create a LINQ query that projects all items in the shoppingcart into shapes
            var query = from item in Items
                        from taskPart in taskParts
                        where taskPart.Id == item.TaskId
                        select new TaskQuantity {
                            TaskPart = taskPart
                           
                        };

            return query;
        }

    }
    }