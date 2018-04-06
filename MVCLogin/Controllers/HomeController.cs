using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLogin.Models;

namespace MVCLogin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Display()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Index(MVCLogin.Models.Product productModel)
        {
            using (ShoppingEntities db = new ShoppingEntities())
            {
                int xyx = Convert.ToInt32(Session["ProductId"]);
                var data = db.Proc_Product().ToList();
                ViewBag.productDetails = data;
                //Product productDetails = db.Products.Where(c => c.ProductId == xyx).FirstOrDefault();
                if (ViewBag.productDetails == null)
                {
                    productModel.ErrorMessage = "No images";
                    return RedirectToAction("Display", ViewBag.productDetails);
                }
                else
                {
                    return RedirectToAction("Display", "Home");
                }
            }
                       
        }        
    }
}