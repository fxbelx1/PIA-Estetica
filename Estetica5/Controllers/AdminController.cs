using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Estetica5.Models;
using System.Web.Security;

namespace Estetica5.Controllers
{
    public class AdminController : Controller
    {
        private PContext db = new PContext();
        // GET: Admin
       
        public ActionResult Index()
        {
            /*List<Cita> listaCita = new List<Cita>();
            listaCita = db.Citas.Include(x => x.Servicio).Include(y => y.Empleado).ToList();
            return View(listaCita);
             */
            return RedirectToAction("Index", "Citas");
            
        }
    }
}