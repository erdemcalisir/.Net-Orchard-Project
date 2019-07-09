using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;


namespace Erdem.TodoList {
    public class Migrations : DataMigrationImpl {

        public int Create() {

            SchemaBuilder.CreateTable("TaskPartRecord", table => table

                // The following method will create an "Id" column for us and set it is the primary key for the table
                .ContentPartRecord()

                // Create a column named "UnitPrice" of type "decimal"
                .Column<string>("Title")

                .Column<string>("Content")

                // Create the "Sku" column and specify a maximum length of 50 characters
                .Column<bool>("Statu")
                );

            // Return the version that this feature will be after this method completes
            return 1;
        }
        public int UpdateFrom1() {

            // Create (or alter) a part called "ProductPart" and configure it to be "attachable".
            ContentDefinitionManager.AlterPartDefinition("TaskPart", part => part
                .Attachable());

            return 2;
        }

    }
}