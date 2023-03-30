using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trifo_Inventory_Management_.Models;
using Trifo_Inventory_Management_.Models.ef;

namespace Trifo_Inventory_Management_.Controllers
{
    public class WarehouseController : Controller
    {
        // GET: Warehouse
      
        public ActionResult Index()
        {
            var db = new dbContext();
            var emp = db.Warehouse.ToList();
            return View(emp);
        }
        public ActionResult ViewWarehouse()
        {
            var db = new dbContext();
            var sh = db.Warehouse;
            return View(sh);

        }


        [HttpGet]
        public ActionResult AddToWarehouse()
        {
            return View();
        }



        [HttpPost]
        public ActionResult AddToWarehouse(Warehouse h)
        {
            var db = new dbContext();
            db.Warehouse.Add(h);
            db.SaveChanges();
            return Redirect("ViewWarehouse");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new dbContext();
            var Warehouses = (from sh in db.Warehouse
                         where sh.Ware_prd_id  == id
                         select sh).SingleOrDefault();
            return View(Warehouses);
        }



        [HttpPost]
        public ActionResult Edit(Warehouse h)
        {
            var db = new dbContext();
            var Warehouses = (from sh in db.Warehouse
                         where sh.Ware_prd_id  == h.Ware_prd_id 
                         select sh).SingleOrDefault();
            Warehouses.Product_name = h.Product_name;
            Warehouses.country = h.country;
            Warehouses.Description = h.Description;
            Warehouses.Picture = h.Picture;
            Warehouses.sell_date = h.sell_date;
            Warehouses.Buy_Price = h.Buy_Price;
            Warehouses.Sell_Price = h.Sell_Price;
            Warehouses.Selled_Quantity = h.Selled_Quantity;
            Warehouses.Customer_name = h.Customer_name;
            Warehouses.CustomerEmail = h.CustomerEmail;
            Warehouses.Customer_mobiler = h.Customer_mobiler;

            db.SaveChanges();
            return Redirect("ViewWarehouse");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new dbContext();
            var Warehouses = (from sh in db.Warehouse
                         where sh.Ware_prd_id  == id
                         select sh).SingleOrDefault();

            return View(Warehouses);
        }
        [HttpPost]
        public ActionResult Delete(Warehouse sh)
        {
            var db = new dbContext();
            var Warehouses = (from shi in db.Warehouse
                         where shi.Ware_prd_id == sh.Ware_prd_id 
                         select shi).SingleOrDefault();
            db.Warehouse.Remove(Warehouses);
            db.SaveChanges();
            return View(Warehouses);
        }
        public ActionResult Details(int id)
        {
            var db = new dbContext();
            var Warehouses = (from sh in db.Warehouse
                         where sh.Ware_prd_id  == id
                         select sh).SingleOrDefault();


            return Redirect("ViewWarehouse");
        }
    }
}