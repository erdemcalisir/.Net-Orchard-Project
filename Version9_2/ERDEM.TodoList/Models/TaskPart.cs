using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;


namespace ERDEM.TodoList.Models {
    public class TaskPart : ContentPart<TaskPartRecord> {

        public string Title {
            get { return Record.Title; }
            set { Record.Title = value; }
        }

        public string Content {
            get { return Record.Content; }
            set { Record.Content = value; }
        }

        public bool Statu {
            get { return Record.Statu; }
            set { Record.Statu = value; }
        }

        //public DateTime CreatedUtc {
        //    get { return Record.CreatedUtc; }
        //    set { Record.CreatedUtc = value; }
        //}
       
    }
}
