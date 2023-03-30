using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
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
        public ActionResult AddToshop(Shop h)
        {
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
            Shops.Selled_Quantity=h.Selled_Quantity;
            Shops.Customer_name=h.Customer_name;
            Shops.CustomerEmail=h.CustomerEmail;
            Shops.Customer_mobiler=h.Customer_mobiler;

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
            return View(Shops);
        }
        public ActionResult Details(int id)
        {
            var db = new dbContext();
            var Shops = (from sh in db.Shop
                         where sh.Shop_prd_id == id
                         select sh).SingleOrDefault();


            return Redirect("ViewShop");
        }




    }
}