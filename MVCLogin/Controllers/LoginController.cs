using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLogin.Models;
namespace MVCLogin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(User userModel)
        {
            using (ShoppingEntities db = new ShoppingEntities())
            {
                var userDetails = db.Users.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();                
                if (userDetails == null)
                {
                    userModel.ErrorMessage = "Invalid User Name or Password";
                    return View("Index", userModel);
                }
                else
                {

                    Session["Id"] = userDetails.UserId;
                    Session["UserName"] = userDetails.UserName;
                    Session["ProductId"] = userDetails.ProductId;
                    return RedirectToAction("Index", "Home",userModel);
                }
            }
        }
        
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}