using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Erdem.TodoList.Models;

namespace Erdem.TodoList.Handlers {
    public class TaskHandler : ContentHandler {

        public TaskHandler(
            IRepository<TaskPartRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}