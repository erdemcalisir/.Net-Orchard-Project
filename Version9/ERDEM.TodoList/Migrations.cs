using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace ERDEM.TodoList {
    public class Migrations : DataMigrationImpl {

        public int Create() {

            SchemaBuilder.CreateTable("TaskPartRecord", table => table
                .ContentPartRecord()
                .Column<string>("Title", column => column.WithLength(20))
                .Column<string>("Content", column => column.WithLength(50))
                .Column<bool>("Statu")
                //.Column<DateTime>("CreatedUtc")
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