﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using ERDEM.TodoList.Models;

namespace ERDEM.TodoList.Handlers {
    public class TaskPartHandler : ContentHandler {
        public TaskPartHandler(IRepository<TaskPartRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}