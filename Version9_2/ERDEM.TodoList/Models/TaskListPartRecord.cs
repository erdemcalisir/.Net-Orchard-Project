using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;


namespace ERDEM.TodoList.Models {
    public class TaskListPartRecord : ContentPartRecord {

        public virtual string TaskList { get; set; }
    }
}