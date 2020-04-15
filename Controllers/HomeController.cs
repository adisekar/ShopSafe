using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopSafe_Web.EntityFramework;
using ShopSafe_Web.Models;

namespace ShopSafe_Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SelectVM model = new SelectVM();
            using (var shopSafeEntity = new ShopSafeEntities())
            {
                var stores = shopSafeEntity.Stores.ToList();
                var locations = shopSafeEntity.Locations.ToList();

                model.Stores = stores;
                model.Locations = locations;
            }

            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SelectVM model)
        {
            if (ModelState.IsValid)
            {
                // Store Store, Location and capacity
                Session["StoreId"] = model.StoreId;
                Session["LocationId"] = model.LocationId;

                return RedirectToAction("Count", "Home");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Count()
        {
            string storeName = string.Empty;
            string locationName = string.Empty;
            string maxCapacity = string.Empty;
            string currentCapacity = string.Empty;

            int storeId = (int)Session["StoreId"];
            int locationId = (int)Session["LocationId"];

            using (var shopSafeEntity = new ShopSafeEntities())
            {
                var storeEntity = shopSafeEntity.Stores.Where(s => s.Id == storeId).FirstOrDefault();
                var locationEntity = shopSafeEntity.Locations.Where(l => l.Id == locationId).FirstOrDefault();
                var userStoreLocationEntity = shopSafeEntity.Store_Location.Where(i => i.Store_Id == storeId && i.Location_Id== locationId).FirstOrDefault();
               

                storeName = storeEntity.Name;
                locationName = locationEntity.Name;
                maxCapacity = (userStoreLocationEntity.Capacity_Id * 10).ToString();
                currentCapacity = userStoreLocationEntity.Current_Capacity.ToString();
            }

            ViewBag.Store = storeName;
            ViewBag.Location = locationName;
            ViewBag.MaxCapacity = maxCapacity;
            ViewBag.CurrentCapacity = currentCapacity;

            return View();
        }
    }
}