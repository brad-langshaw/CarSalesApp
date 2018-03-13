using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace CarSalesApp1.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            

            return View();
        }
        public ActionResult Login()
        {
          

            return View();
        }
        [HttpPost]
        public ActionResult Login(HttpPostAttribute httpPost)
        {
            string username, password;
            username = Request.Form["username"];
            password = Request.Form["password"];


            // connect and verify username password
            return RedirectToAction("Store");


        }
        public ActionResult SignUp()
        {


            return View();
        }

        // Validator.Regex()
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "username,name,lastName,password")] User user)
        {
            if (ModelState.IsValid)
            {
                var db = new StoreDBEntities();
                //string username, name, lastName, password;
                //username = Request.Form["username"];
                //name = Request.Form["name"];
                //lastName = Request.Form["lastname"];
                //password = Request.Form["password"];
                //CarSalesApp1.User user = new CarSalesApp1.User(username, name, lastName, password);
                //using (var db = new CarSalesApp1.StoreDBEntities())
                    db.Users.Add(user);
                    db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return View();
            }
        public ActionResult Store()
        {

            return View();
        }
        
        [HttpGet]
        public ActionResult Merchandise()
        {
        
            return View();
        }
        [HttpPost]
        public ActionResult Merchandise(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Home/images"), fileName);
                    file.SaveAs(path);
                 
                   
                        string make, style, engine, imageURL, description;
                        double price = 0;



                        imageURL = fileName;
                        make = Request.Form["make"];
                        style = Request.Form["style"];
                        description = Request.Form["description"];
                        price = Double.Parse(Request.Form["price"]); // Convert.ToDouble()
                        engine = Request.Form["engine"];
                        Merchandise merchandise = new Merchandise(1005, make, style, price,
                engine, imageURL, description);
                        using (var db = new StoreDBEntities())
                        {
                            db.Merchandises.Add(merchandise);
                            db.SaveChanges();
                        }
                    
                }
                ViewBag.Message = "Upload successful";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Upload failed";
                return RedirectToAction("");
            }
        }
    }
}
