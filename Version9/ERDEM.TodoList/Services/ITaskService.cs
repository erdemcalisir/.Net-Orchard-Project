using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERDEM.TodoList.Models;
using Orchard;


namespace ERDEM.TodoList.Services {
    public interface ITaskService : IDependency {
        void CreateTask(string title, string content, bool statu);
        void DeleteTask(int taskId);
        void TrueTask(int taskId);
        void FalseTask(int taskId);   

    }
}