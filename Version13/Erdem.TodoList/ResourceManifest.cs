using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.UI.Resources;


namespace Erdem.TodoList {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            manifest.DefineStyle("Task").SetUrl("Task.css");






            //var manifest = builder.Add();
            //manifest.DefineScript("Layouts.Lib")
            //  .SetUrl("Lib.min.js", "Lib.js")
            //  .SetDependencies("jQuery");
            //manifest.DefineScript("Layouts.Models")
            //  .SetUrl("Models.min.js", "Models.js")
            //  .SetDependencies("jQuery", "Layouts.Lib");
        }
    }
}