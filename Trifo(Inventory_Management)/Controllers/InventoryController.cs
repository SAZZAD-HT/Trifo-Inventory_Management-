using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
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

    }
}