using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;


namespace Erdem.Todolist.Models {
    public class TaskPart : ContentPart<TaskPartRecord> {

        public string Title {
            get { return Record.Title; }
            set { Record.Title = value; }
        }
        public string Content {
            get { return Record.Content; }
            set { Record.Content = value; }
        }
        public Boolean State {
            get { return Record.State; }
            set { Record.State = value; }
        }

    }
}