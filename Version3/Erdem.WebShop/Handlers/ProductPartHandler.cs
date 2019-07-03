using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Erdem.WebShop.Models;

namespace Erdem.WebShop.Handlers {
    public class ProductPartHandler : ContentHandler {
        public ProductPartHandler(IRepository<ProductPartRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}