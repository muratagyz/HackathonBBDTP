using BBDTP.EntityFramework;
using BBDTP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBDTP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Exit()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
        public ActionResult Panel()
        {
            using (Context c = new Context())
            {
                List<SelectListItem> regions = (from x in c.Regions
                                                select new SelectListItem
                                                {
                                                    Text = x.RegionName,
                                                    Value = x.RegionId.ToString()
                                                }).ToList();

                List<SelectListItem> cities = (from x in c.Cities
                                               select new SelectListItem
                                               {
                                                   Text = x.CityName,
                                                   Value = x.CityId.ToString()
                                               }).ToList();

                var rainsYear = (from Rain in c.Rains
                                 select Rain.RainYear).ToArray<string>();

                var rainsQuantity = (from Rain in c.Rains
                                     select Rain.RainQuantity).ToArray<int>();
                ViewBag.vlct = cities;
                ViewBag.vlr = regions;
                ViewBag.vlRainYear = rainsYear;
                ViewBag.vlRainQuantity = rainsQuantity;
                return View();
            }
        }
        [HttpPost]
        public ActionResult Login(FarmDto p)
        {
            Session["Checked"] = "false";
            using (Context c = new Context())
            {
                var user = c.Farms.FirstOrDefault(x => x.FarmdName == p.FarmdName && x.FarmPassword == p.FarmPassword);
                if (user != null)
                {
                    Session["Checked"] = "true";
                    Session["Name"] = user.FarmdName;
                    return RedirectToAction("Panel");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }
    }
}