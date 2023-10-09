using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ToolController : Controller
    {
        private readonly Client _client = new Client();



        public static GridViewSettings GetToolGridViewSettings()
        {
            var settings = new GridViewSettings
            {
                Width = Unit.Percentage(100),
                Name = "ToolGrid"
            };


            settings.Columns.Add(x =>
           {
               x.FieldName = "IdTool";
               x.Caption = "Id Tool";
               x.ColumnType = MVCxGridViewColumnType.TextBox;
               
           });

            settings.Columns.Add(x =>
            {
                x.FieldName = "BoschCode";
                x.Caption = "Codice Bosch";
                x.ColumnType = MVCxGridViewColumnType.TextBox;
            });

            settings.Columns.Add(x =>
            {
                x.FieldName = "Description";
                x.Caption = "Descrizione";
                x.ColumnType = MVCxGridViewColumnType.TextBox;
            });

            settings.Columns.Add(x =>
            {
                x.FieldName = "PrimarySupplier";
                x.Caption = "Fornitore Primario";
                x.ColumnType = MVCxGridViewColumnType.TextBox;
            });

            settings.Columns.Add(x =>
            {
                x.FieldName = "SecondarySupplier";
                x.Caption = "Fornitore Secondario";
                x.ColumnType = MVCxGridViewColumnType.TextBox;
            });

            settings.Columns.Add(x =>
            {
                x.FieldName = "Quantity";
                x.Caption = "Quantità";
                x.ColumnType = MVCxGridViewColumnType.TextBox;
            });

            settings.CallbackRouteValues = new { Controller = "Tool", Action = "RefreshToolGrid" };
            return settings;


        }


        public async Task<ActionResult> RefreshToolGrid()
        {
            var tools = (await _client.GetAll()).ToList();

            return PartialView("ToolGridView", tools);
        }


        public async Task<ActionResult> GetAll()
        {
            List<Tool> tools = (await _client.GetAll()).ToList();
            return View(tools);
        }

    }  
}
