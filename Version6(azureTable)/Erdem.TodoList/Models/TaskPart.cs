using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;


namespace Erdem.TodoList.Models {
    public class TaskPart : ContentPart<TaskPartRecord> {
        public string TaskTitle {
            get { return Record.TaskTitle; }
            set { Record.TaskTitle = value; }
        }
        public string TaskContent {
            get { return Record.TaskContent; }
            set { Record.TaskContent = value; }
        }
        public bool TaskStatu {
            get { return Record.TaskStatu; }
            set { Record.TaskStatu = value; }
        }
    }
}