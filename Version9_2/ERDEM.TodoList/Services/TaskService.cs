using Orchard;
using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.Services;
using ERDEM.TodoList.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ERDEM.TodoList.Services {
    public class TaskService : ITaskService{

        private readonly IOrchardServices _orchardServices;
        private readonly IMembershipService _membershipService;
        private readonly IClock _clock;

        public TaskService(IOrchardServices orchardServices, IClock clock) {
            _orchardServices = orchardServices;
            _clock = clock;
        }

        public void CreateTask(string title, string content, bool statu) {
            // New up a new content item of type "Customer"
            var task = _orchardServices.ContentManager.New("Task");

            // Cast the customer to a CustomerPart
            var taskPart = task.As<TaskPart>();

            // Set some properties of the customer content item (via UserPart and CustomerPart)
            taskPart.Title = title;
            taskPart.Content = content;
            taskPart.Statu = statu;

            // Use IClock to get the current date instead of using DateTime.Now (see http://skywalkersoftwaredevelopment.net/orchard-development/api/iclock)
            //taskPart.CreatedUtc = DateTime.MinValue;

            // Use Ochard's MembershipService to set the password of our new user

            // Store the new user into the database
            _orchardServices.ContentManager.Create(task);
        }
        public void DeleteTask(int taskId) {
            _orchardServices.ContentManager.Remove(
            _orchardServices.ContentManager.Get<TaskPart>(taskId).ContentItem);
        }

        public void TrueTask(int taskId) {
            ContentItem content = _orchardServices.ContentManager.Get(taskId).Content;
            TaskPart taskPart = (TaskPart)content.Parts.ElementAt(1);
            taskPart.Statu = true;
            _orchardServices.ContentManager.Create(content);
        }
        public void FalseTask(int taskId) {
            ContentItem content = _orchardServices.ContentManager.Get(taskId).Content;
            TaskPart taskPart = (TaskPart)content.Parts.ElementAt(1);
            taskPart.Statu = false;
            _orchardServices.ContentManager.Create(content);
        }
        public List<TaskPart> GetTask(int taskId) {
            List<TaskPart> list = _orchardServices.ContentManager.Query<TaskPart, TaskPartRecord>().Where(x => x.Id == taskId).List().ToList();

            return list;

        }
    }
}