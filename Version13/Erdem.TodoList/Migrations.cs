using Orchard.ContentManagement.MetaData;
using Orchard.Core.Common.Models;
using Orchard.Data.Migration;
using Erdem.TodoList.Models;
using Orchard.Widgets.Models;
using Orchard.Core.Contents.Extensions;

namespace Erdem.TodoList {
    public class Migrations : DataMigrationImpl {

        public int Create() {
            ContentDefinitionManager.AlterTypeDefinition(
              "TaskWidget", cfg => cfg
                .WithSetting("Stereotype", "Widget")
                .WithPart(typeof(TaskPart).Name)
                .WithPart(typeof(CommonPart).Name)
                .WithPart(typeof(WidgetPart).Name));
            return 1;
        }
        public int UpdateFrom1() {
            SchemaBuilder.CreateTable(typeof(TaskPartRecord).Name,
              table => table
                .ContentPartRecord()
                .Column<string>("Description")
                .Column<bool>("IsOnSale"));
            return 2;
        }
        public int UpdateFrom2() {
            ContentDefinitionManager.AlterPartDefinition(
              typeof(TaskPart).Name, part => part
              .WithDescription(
                "Renders information about the current featured product."));

            return 3;
        }
    }
}