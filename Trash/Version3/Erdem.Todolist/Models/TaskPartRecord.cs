using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;

namespace Erdem.Todolist.Models {
    public class TaskPartRecord : ContentPartRecord {

        public virtual string Title { get; set; }
        public virtual string Content { get; set; }
        public virtual Boolean State { get; set; }

    }
}