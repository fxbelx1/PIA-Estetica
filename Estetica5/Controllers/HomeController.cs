using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Estetica5.Models;
using System.Web.Security;

namespace Estetica5.Controllers
{
    public class HomeController : Controller
    {
        private PContext db = new PContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Form(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }

        [HttpPost]
        public ActionResult Login(int id, string clave)
        {
            if (!String.IsNullOrEmpty(clave))
            {
                var user = db.Empleados.FirstOrDefault(e => e.Id == id && e.Clave == clave);
                if (user != null)  
                {
                    FormsAuthentication.SetAuthCookie(user.Id.ToString(), true);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Form", new { message = "No encontramos tus datos" });
                }
            }
            else
            {
                return RedirectToAction("Form", new { message = "Llena los campos" });
            }
        }

        public ActionResult Listaser()
        {
            return View(db.Servicios.ToList());
        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }






    }
}