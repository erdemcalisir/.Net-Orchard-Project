using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using ERDEM.TodoList.Models;

namespace ERDEM.TodoList.Handlers {
    public class TaskListPartHandler : ContentHandler {
        public TaskListPartHandler(IRepository<TaskListPartRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}