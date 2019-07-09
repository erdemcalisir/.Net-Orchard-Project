using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard;
using Erdem.TodoList.Models;

namespace Erdem.TodoList.Services {
    public interface ITodoListService : IDependency {
        IEnumerable<TodoListItem> Items { get; }

        void Add(int taskId, string taskTitle, string taskContent, bool taskStatu = false);
        void Remove(int taskId);
        TaskPart GetProduct(int taskId);
    }
}