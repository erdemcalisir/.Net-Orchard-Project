using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.UI.Resources;


namespace Erdem.TodoList {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            // Create and add a new manifest
            var manifest = builder.Add();
 
            // Define a "common" style sheet
            manifest.DefineStyle("Erdem.TodoList.Common").SetUrl("common.css");
 
            // Define the "shoppingcart" style sheet
            manifest.DefineStyle("Erdem.TodoList.TodoList").SetUrl("todolist.css").SetDependencies("Erdem.TodoList.Common");
        }
    }
}