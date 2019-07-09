using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;

namespace Erdem.TodoList.Models {
    public class TaskPartRecord : ContentPartRecord {
        public virtual string TaskTitle { get; set; }
        public virtual string TaskContent { get; set; }
        public virtual bool TaskStatu { get; set; }
    }
}