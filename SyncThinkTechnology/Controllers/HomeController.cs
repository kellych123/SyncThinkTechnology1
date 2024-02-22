using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SyncThinkTechnology.Models;
using System.Data;

namespace SyncThinkTechnology.Controllers
{
    public class HomeController : Controller
    {
        SyncThinkDatabaseEntities db = new SyncThinkDatabaseEntities();

        public ActionResult Index(string searching)
        {
            DataSet1 dataSet = new DataSet1();
            DataTable table = new DataTable("Products");
            dataSet.Tables.Add(table);

            return View(db.Products.Where(x => x.ProductBarcode.ToString().Contains(searching) || searching == null).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}