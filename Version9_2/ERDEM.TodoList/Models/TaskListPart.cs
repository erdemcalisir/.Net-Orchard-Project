using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;


namespace ERDEM.TodoList.Models {
    public class TaskListPart : ContentPart<TaskListPartRecord> {
        public string TaskList {
            get { return Record.TaskList; }
            set { Record.TaskList = value; }
        }
    }
}