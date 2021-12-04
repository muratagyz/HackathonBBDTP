using BBDTP.EntityFramework;
using BBDTP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBDTP.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Product()
        {
            using (Context c = new Context())
            {
                List<ProductDto> products = (from p in c.Products
                                             join x in c.Categories on p.CategoryId equals x.CategoryId
                                             join y in c.Cities on p.CityId equals y.CityId
                                             join z in c.Farms on p.FarmId equals z.FarmdId
                                             select new ProductDto
                                             {
                                                 ProductId = p.ProductId,
                                                 ProductName = p.ProductName,
                                                 ProductStock = p.ProductStock,
                                                 CategoryName = x.CategoryName,
                                                 CityName = y.CityName,
                                                 FarmName = z.FarmdName,
                                                 RegionName = y.Region.RegionName

                                             }).ToList();

                return View(products);
            }
        }
        [HttpGet]
        public ActionResult ProductAdd()
        {
            using (Context c = new Context())
            {
                List<SelectListItem> categories = (from x in c.Categories
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
                List<SelectListItem> cities = (from x in c.Cities
                                               select new SelectListItem
                                               {
                                                   Text = x.CityName,
                                                   Value = x.CityId.ToString()
                                               }).ToList();
                List<SelectListItem> farms = (from x in c.Farms
                                              select new SelectListItem
                                              {
                                                  Text = x.FarmdName,
                                                  Value = x.FarmdId.ToString()
                                              }).ToList();
                ViewBag.vlc = categories;
                ViewBag.vlct = cities;
                ViewBag.vlf = farms;
                return View();
            }

        }
        [HttpPost]
        public ActionResult ProductAdd(Product product)
        {
            using (Context c = new Context())
            {
                c.Products.Add(product);
                c.SaveChanges();
            }
            return RedirectToAction("Product");

        }

      
    }
}