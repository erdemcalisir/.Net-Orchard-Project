using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Erdem.TodoList.Models {

    [Serializable]
    public sealed class TodoListItem {
        public int TaskId { get; private set; }

        public string TaskTitle { get; set; }
        public string TaskContent { get; set; }

        public bool TaskStatu { get; set; }

        //private int _quantity;
        //public int Quantity {
        //    get { return _quantity; }
        //    set {
        //        if (value < 0)
        //            throw new IndexOutOfRangeException();

        //        _quantity = value;
        //    }
        //}
        public TodoListItem() {}

        public TodoListItem(int taskId, string taskTitle, string taskContent , bool taskStatu = false){
            TaskId = taskId;
            TaskTitle = taskTitle;
            TaskContent = taskContent;
            TaskStatu = taskStatu;
        }   
    }
}


