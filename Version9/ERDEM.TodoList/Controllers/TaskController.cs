using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERDEM.TodoList.Services;
using Orchard;

namespace ERDEM.TodoList.Controllers
{
    public class TaskController : Controller
    {
        public IOrchardServices Services { get; set; }
        private readonly ITaskService _taskService;
        public TaskController(IOrchardServices services, ITaskService taskService) {
            Services = services;
            _taskService = taskService;
        }
        public bool CreateTask(string title, string content, bool statu) {
            try {
                _taskService.CreateTask(title, content, statu);
                return true;
            }
            catch (Exception exception) {
                Console.WriteLine(exception);
                return false;
            }

        }
        public bool Delete(int id) {
            try {
                _taskService.DeleteTask(id);
                return true;
            }
            catch (Exception exception) {
                Console.WriteLine(exception);
                return false;
            }

        }
        //finish
        public bool TrueTask(int id) {
            try {
                _taskService.TrueTask(id);
                return true;
            }
            catch (Exception exception) {
                Console.WriteLine(exception);
                return false;
            }
        }
        //todo
        public bool FalseTask(int id) {
            try {
                _taskService.FalseTask(id);
                return true;
            }
            catch (Exception exception) {
                Console.WriteLine(exception);
                return false;
            }

        }

        // GET: Task
        public ActionResult Index()
        {
            return View();
        }
    }
}