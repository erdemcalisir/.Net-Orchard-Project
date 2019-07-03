﻿using Orchard.ContentManagement.Records;


namespace Erdem.WebShop.Models {
    public class ProductPartRecord : ContentPartRecord {
        public virtual decimal UnitPrice { get; set; }
        public virtual string Sku { get; set; }
    }
}