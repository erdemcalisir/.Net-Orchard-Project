using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;

namespace Erdem.TodoList.Models {
    public class TaskPartRecord : ContentPartRecord {

        public virtual string Description {get; set; }
        public virtual bool IsDone { get; set; }
    }
}