using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Erdem.TodoList.Models {
    [Serializable]
    public sealed class TaskListCartItem {

        public int TaskId { get; private set; }

        public TaskListCartItem() {
        }

        public TaskListCartItem(int taskId) {
            TaskId = taskId ;
        }
    }
}