using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orchard;

namespace Erdem.TodoList.Services {
    public interface ITaskService : IDependency {
        bool IsOnFeaturedProductPage();

    }
}
