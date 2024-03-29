﻿using Erdem.WebShop.Services;
using Orchard;
using Orchard.Mvc;
using System.Web.Mvc;

namespace Erdem.WebShop.Controllers {
    public class ShoppingCartController : Controller {
        private readonly IShoppingCart _shoppingCart;
        private readonly IOrchardServices _services;

        public ShoppingCartController(IShoppingCart shoppingCart, IOrchardServices services) {
            _shoppingCart = shoppingCart;
            _services = services;
        }

        [HttpPost]
        public ActionResult Add(int id) {

            // Add the specified content id to the shopping cart with a quantity of 1.
            _shoppingCart.Add(id, 1);

            // Redirect the user to the Index action (yet to be created)
            return RedirectToAction("Index");
        }

        public ActionResult Index() {

            // Create a new shape using the "New" property of IOrchardServices.
            var shape = _services.New.ShoppingCart();

            // Return a ShapeResult
            return new ShapeResult(this, shape);
        }
    }
}