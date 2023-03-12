using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices.Internal;
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
            var db = new dbContext(); // Replace with your own DbContext class
            var monthlySales = db.Products
                .Where(s => s.sell_date.ToString().Month== DateTime.Now.Month && s.sell_date.Year == DateTime.Now.Year)
                .GroupBy(s => s.sell_date.Day)
                .Select(g => new { Day = g.Key, TotalSales = g.Sum(s => s.Quantity * s.Price) })
                .OrderBy(g => g.Day)
                .ToList();

            // Create a chart to display the monthly sales data
            var chart = new Chart(width: 600, height: 400)
                .AddTitle("Monthly Sales Chart")
                .AddSeries(
                    chartType: "column",
                    xValue: monthlySales.Select(s => s.Day).ToArray(),
                    yValues: monthlySales.Select(s => s.TotalSales).ToArray()
                );

            // Convert the chart to a byte array for display in the view
            var chartData = chart.GetBytes();

            // Pass the chart data to the view
            ViewBag.ChartData = chartData;
            return View();
        }
        public ActionResult Pie_chart_Monthly_sale_Category()
        {
            return View();
        }
    }
}