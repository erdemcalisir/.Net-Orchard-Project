﻿using Orchard.ContentManagement;

namespace Erdem.WebShop.Models {
    public class ProductPart : ContentPart<ProductPartRecord> {
        public decimal UnitPrice {
            get { return Record.UnitPrice; }
            set { Record.UnitPrice = value; }
        }

        public string Sku {
            get { return Record.Sku; }
            set { Record.Sku = value; }
        }
    }
}