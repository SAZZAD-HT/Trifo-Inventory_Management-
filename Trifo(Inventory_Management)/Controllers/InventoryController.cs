using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices.Internal;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Trifo_Inventory_Management_.Models;

namespace Trifo_Inventory_Management_.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChartShow()
        {
            return View();
        }
        public ActionResult ProfitGraph()
        {
            var db = new dbContext();
            List<selled_product> productList = new List<selled_product>();
            //var buyingPrices = db.Products.Select(p => p.Buy_Price).ToArray();
            //var sellingPrices = db.Products.Select(p => p.Sell_Price).ToArray();
            //var profits = new double[buyingPrices.Length];


            //for (int i = 0; i < buyingPrices.Length; i++)
            //{
            //    profits[i] = sellingPrices[i] - buyingPrices[i];

            // Create a dictionary to store profit data
            Dictionary<string,Double> profitData = new Dictionary<string, Double>();

            // Calculate profit for each product and add it to the dictionary
            foreach (selled_product product in db.Products)
            {
                Double profit = product.Sell_Price - product.Buy_Price;
                string prodctId = "Product " + product.sPid;
                profitData.Add(prodctId, profit);
            }

            ViewBag.Profits = profitData;
            return View();
        }
        public ActionResult Line_chart_Monthly_sale()
        {
            //var db = new dbContext(); // Replace with your own DbContext class
            //var monthlySales = db.Products
            //    .Where(s => s.sell_date.ToString().Month== DateTime.Now.Month && s.sell_date.Year == DateTime.Now.Year)
            //    .GroupBy(s => s.sell_date.Day)
            //    .Select(g => new { Day = g.Key, TotalSales = g.Sum(s => s.Quantity * s.Price) })
            //    .OrderBy(g => g.Day)
            //    .ToList();

            //// Create a chart to display the monthly sales data
            //var chart = new Chart(width: 600, height: 400)
            //    .AddTitle("Monthly Sales Chart")
            //    .AddSeries(
            //        chartType: "column",
            //        xValue: monthlySales.Select(s => s.Day).ToArray(),
            //        yValues: monthlySales.Select(s => s.TotalSales).ToArray()
            //    );

            //// Convert the chart to a byte array for display in the view
            //var chartData = chart.GetBytes();

            //// Pass the chart data to the view
           // ViewBag.ChartData = chartData;
            return View();
        }
        public ActionResult Pie_chart_Monthly_sale_Category()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddToInventory()
        {
            return View();
        }
        //forhad
        [HttpPost]
        public ActionResult AddToInventory(Inventory IN,HttpPostedFileBase file)
        {
            var db = new dbContext();
            if (file != null && file.ContentLength > 0)
            {

                //var fileName = Path.GetFileName(file.FileName);
                //var fileExtension = Path.GetExtension(fileName);
                //var newFileName = Guid.NewGuid().ToString() + fileExtension;
                //var path = Path.Combine(Server.MapPath("~/App_data/pic_uploaded"), newFileName);
                //file.SaveAs(path);
                //var filePath = $"~/App_data/pic_uploaded/{newFileName}";
                //PA.pic=filePath;

                var path = Server.MapPath("~/App_data/PicturesSave"); 
                var maxNumber = Directory.GetFiles(path)
                    .Select(f => Path.GetFileNameWithoutExtension(f))
                    .Where(f => f.StartsWith("pic"))
                    .Select(f => int.Parse(f.Substring(3)))
                    .DefaultIfEmpty(0)
                    .Max();
                var newFileName = $"pic{maxNumber + 1}{Path.GetExtension(file.FileName)}";
                var fullPath = Path.Combine(path, newFileName);
                file.SaveAs(fullPath);
                IN.Picture  = fullPath;
            }
            if (IN.Quantity != null)
            {
                IN.stock = "IN STOCK";
            }
            else
            {
                IN.stock = "OUT OF STOCK";

            }
            db.Inventory.Add(IN); 
            db.SaveChanges();
            return RedirectToAction("succesfullyAction_Performed");
        }
        public ActionResult succesfullyAction_Performed()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Sell()
        {
            var db = new dbContext();
            var inventory = db.Inventory;
            ViewBag.Inventory = inventory;
            return View();
           
        }
        [HttpPost]
        public ActionResult Selll(selled_product SL,int id)
        {
            var db = new dbContext();
            
            
            return RedirectToAction("succesfullyAction_Performed");
        }
    }
}