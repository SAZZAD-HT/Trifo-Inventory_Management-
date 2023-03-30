using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult AddToWarehouse(Warehouse h, HttpPostedFileBase file)
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
                h.Picture = fullPath;
            }
            if (h.Quantity != null)
            {
                h.stock = "IN STOCK";
            }
            else
            {
                h.stock = "OUT OF STOCK";

            }
          
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
            Warehouses.Quantity = h.Quantity;
            Warehouses.Customer_name = h.Customer_name;
            Warehouses.CustomerEmail = h.CustomerEmail;
            Warehouses.Customer_mobiler = h.Customer_mobiler;
            Warehouses.stock=h.stock;

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


            return View(Warehouses);
        }
    }
}