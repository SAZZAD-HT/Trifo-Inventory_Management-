using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Trifo_Inventory_Management_.Models;
using Trifo_Inventory_Management_.Models.ef;

namespace Trifo_Inventory_Management_.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop

        public ActionResult Index()
        {
            var db = new dbContext();
            var emp = db.Shop.ToList();
            return View(emp);
        }
        public ActionResult Viewshop() {
            var db = new dbContext();
            var sh = db.Shop;
            return View(sh); 
        
        }


       [HttpGet]
        public ActionResult AddToshop()
        {
            return View();
        }
        
        
        
      [HttpPost]
        public ActionResult AddToshop(Shop h, HttpPostedFileBase file)
        {

            if (file != null && file.ContentLength > 0)
            {

             
                var path = Server.MapPath("~/Content/images");
                var maxNumber = Directory.GetFiles(path)
                    .Select(f => Path.GetFileNameWithoutExtension(f))
                    .Where(f => f.StartsWith("pic"))
                    .Select(f => int.Parse(f.Substring(3)))
                    .DefaultIfEmpty(0)
                    .Max();
                var newFileName = $"pic{maxNumber + 1}{Path.GetExtension(file.FileName)}";
                var fullPath = Path.Combine(path, newFileName);
                file.SaveAs(fullPath);
                h.sPicture = fullPath;
            }
            if (h.Quantity != null)
            {
                h.stock = "IN STOCK";
            }
            else
            {
                h.stock = "OUT OF STOCK";

            }
            var db = new dbContext();
            db.Shop.Add(h);
            db.SaveChanges();
            return Redirect("ViewShop");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db=new dbContext();
            var Shops = (from sh in db.Shop
                         where sh.Shop_prd_id == id
                         select sh).SingleOrDefault();
            return View(Shops);
        }



        [HttpPost]
        public ActionResult Edit(Shop h)
        {
            var db = new dbContext();
            var Shops = (from sh in db.Shop
                         where sh.Shop_prd_id == h.Shop_prd_id
                         select sh).SingleOrDefault();
            Shops.sProduct_name = h.sProduct_name;
            Shops.country=h.country;
            Shops.sDescription=h.sDescription;
            Shops.sPicture=h.sPicture;
            Shops.sell_date=h.sell_date;
            Shops.Buy_Price=h.Buy_Price;
            Shops.Sell_Price = h.Sell_Price;
            Shops.Quantity=h.Quantity;
            Shops.Customer_name=h.Customer_name;
            Shops.CustomerEmail=h.CustomerEmail;
            Shops.Customer_mobiler=h.Customer_mobiler;
            Shops.stock=h.stock;    

            db.SaveChanges();
            return Redirect("ViewShop");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new dbContext();
            var Shops = (from sh in db.Shop
                         where sh.Shop_prd_id == id
                         select sh).SingleOrDefault();

            return View(Shops);
        }
        [HttpPost]
        public ActionResult Delete(Shop sh)
        {
            var db = new dbContext();
            var Shops = (from shi in db.Shop
                         where shi.Shop_prd_id ==sh.Shop_prd_id
                         select shi).SingleOrDefault();
            db.Shop.Remove(Shops);
            db.SaveChanges();
            return Redirect("ViewShop");
        }
        public ActionResult Details(int id)
        {
            var db = new dbContext();
            var Shops = (from sh in db.Shop
                         where sh.Shop_prd_id == id
                         select sh).SingleOrDefault();


            return View(Shops);
        }
        public ActionResult image_cheack()
        {
            var dummy = "G:\\Trifo-Inventory_Management-\\Trifo(Inventory_Management)\\Content\\images\\pic1.jpeg";
            return View(dummy);
        }




    }
}