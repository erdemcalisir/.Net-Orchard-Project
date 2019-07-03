using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Erdem.TodoList.Services;
using Orchard;
using Orchard.Mvc;
using Orchard.Themes;

namespace Erdem.TodoList.Controllers {
    public class TodoListController : Controller {

        private readonly ITodoListService _todoList;
        private readonly IOrchardServices _services;


        public TodoListController(ITodoListService todoList, IOrchardServices services) {
            _todoList = todoList;
            _services = services;

        }
        [HttpPost]
        public ActionResult Add(int id, string title, string content, bool statu = false) {

            _todoList.Add(id, title, content, statu);

            // Redirect the user to the Index action (yet to be created)
            return RedirectToAction("Index");
        }
        [Themed]
        public ActionResult Index() {

            // Create a new shape using the "New" property of IOrchardServices.
            var shape = _services.New.TodoList();

            var query = from item in _todoList.Items
                        let task = _todoList.GetProduct(item.TaskId)
                        select _services.New.TodoListItem(
                            Task: task
                            );
            // Execute the LINQ query and store the results on a property of the shape
            shape.Task = query.ToList();

            // Store the grand total, sub total and VAT of the shopping cart in a property on the shape


            // Return a ShapeResult
            return new ShapeResult(this, shape);
        }
    }
}