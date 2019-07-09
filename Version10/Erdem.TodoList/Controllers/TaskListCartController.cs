using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Erdem.TodoList.Services;
using Orchard.Mvc;
using Orchard;
using Orchard.Themes;

namespace Erdem.TodoList.Controllers
{
    public class TaskListCartController : Controller {

        private readonly ITaskListCart _tasklistCart;
        private readonly IOrchardServices _services;


        public TaskListCartController(ITaskListCart tasklistCart, IOrchardServices services) {
            _tasklistCart = tasklistCart;
            _services = services;
        }
        [HttpPost]
        public ActionResult Add(int id) {

            // Add the specified content id to the shopping cart with a quantity of 1.
            _tasklistCart.Add(id);

            // Redirect the user to the Index action (yet to be created)
            return RedirectToAction("Index");
        }
        //[Themed]
        //public ActionResult Index() {

        //    // Create a new shape using the "New" property of IOrchardServices.
        //    var shape = _services.New.TaskListCart(
        //        Tasks: _tasklistCart.GetProducts().ToList()
        //    );

        //    // Return a ShapeResult
        //    return new ShapeResult(this, shape);
        //}

        [Themed]
        public ActionResult Index() {

            // Create a new shape using the "New" property of IOrchardServices.
            var shape = _services.New.TaskListCart(
                Tasks: _tasklistCart.GetProducts().Select(p => _services.New.TaskListCartItem(
                    TaskPart: p.TaskPart,
                   
                    Title: _services.ContentManager.GetItemMetadata(p.TaskPart).DisplayText)
                ).ToList()
               
            );

            // Return a ShapeResult
            return new ShapeResult(this, shape);
        }

    }
}