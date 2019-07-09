using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard;
using Erdem.TodoList.Models;

namespace Erdem.TodoList.Services {
    public interface ITaskListCart : IDependency{
        IEnumerable<TaskListCartItem> Items { get; }

        void Add(int taskId);
        void Remove(int taskId);
        //TaskPart GetProduct(int taskId);

        IEnumerable<TaskQuantity> GetProducts();
    }
}