using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using ERDEM.TodoList.Models;


namespace ERDEM.TodoList.Drivers {
    public class TaskPartDriver : ContentPartDriver<TaskPart> {
        protected override string Prefix {
            get { return "Task"; }
        }
        protected override DriverResult Editor(TaskPart part, dynamic shapeHelper) {
            return ContentShape("Parts_Task_Edit", () => shapeHelper.EditorTemplate(TemplateName: "Parts/Task", Model: part, Prefix: Prefix));
        }

        protected override DriverResult Editor(TaskPart part, IUpdateModel updater, dynamic shapeHelper) {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
        //protected override DriverResult Display(TaskPart part, string displayType, dynamic shapeHelper) {
        //    return ContentShape("Parts_Task", () => shapeHelper.Parts_Task(
        //            Title: part.Title,
        //            Content: part.Content, 
        //            Statu: part.Statu
        //            //CreatedUtc: part.CreatedUtc
        //        ));
        //}
        protected override DriverResult Display(TaskPart part, string displayType, dynamic shapeHelper) {
            // To return more than 1 shape, use the Combined method to create a "CombinedShapeResult" object.
            return Combined(

                // Shape 1: Parts_Task
                ContentShape("Parts_Task", () => shapeHelper.Parts_Task(
                    Title: part.Title,
                    Content: part.Content,
                    Statu: part.Statu
                )),

                // Shape 2: Parts_Product_AddButton
                ContentShape("Parts_Task_AddButton", () => shapeHelper.Parts_Task_AddButton())
                ); ;
        }
        //protected override DriverResult Display(TaskListPart part, string displayType, dynamic shapeHelper) {
        //    // To return more than 1 shape, use the Combined method to create a "CombinedShapeResult" object.
        //    return Combined(

        //        // Shape 1: Parts_Task
        //        ContentShape("Parts_TaskList", () => shapeHelper.Parts_List(
        //            TaskList: part.TaskList

        //    ))); ;
        //}

    }
}