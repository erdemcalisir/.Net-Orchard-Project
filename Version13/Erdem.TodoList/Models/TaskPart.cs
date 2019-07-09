using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;

namespace Erdem.TodoList.Models {
    public class TaskPart : ContentPart<TaskPartRecord> {

        [DisplayName("description")]
        public string Description {
            get { return Retrieve(r => r.Description); }
            set { Store(r => r.Description, value); }
        }

        [DisplayName("Is done?")]
        public bool IsDone {
            get { return Retrieve(r => r.IsDone); }
            set { Store(r => r.IsDone, value); }
        }
    }
}