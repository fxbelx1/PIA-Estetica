using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Estetica5.Models;

namespace Estetica5.Controllers
{
    public class CitasController : Controller
    {
        private PContext db = new PContext();

        // GET: Citas
        public ActionResult Index()
        {
            List<Cita> listaCita = new List<Cita>();
            listaCita = db.Citas.Include(x => x.Servicio).Include(y => y.Empleado).ToList();
            return View(listaCita);

        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            //DROPDOWNLIST Servicios

           List<Servicio> ddlServicios = new List<Servicio>();
           ddlServicios = db.Servicios.ToList();

            List <SelectListItem> itemsser = ddlServicios.ConvertAll(d =>
              {
                  return new SelectListItem()
                  {
                      Text = d.Nombre.ToString(),
                      Value = d.Id.ToString(),
                      Selected = false
                  };
              }); 
         
            ViewBag.listaServicios = itemsser;

            //DROPDOWNLIST Empleados

            List<Empleado> ddlEmpleados = new List<Empleado>();
            ddlEmpleados = db.Empleados.ToList();

            List<SelectListItem> itemsemp = ddlEmpleados.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.listaEmpleados = itemsemp; 

            return View();
        }

        // POST: Citas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,Hora,Nombre,Telefono,Id_Servicio,Id_Empleado")] Cita cita)
        {

            if (ModelState.IsValid)
            {

                var prueba = cita.Id_Servicio;
                var prueba2 = cita.Id_Empleado;
                Console.Write(prueba + prueba2);
                db.Citas.Add(cita);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // GET: Citas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Citas.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // POST: Citas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Hora,Nombre,Telefono,Id_Servicio,Id_Empleado")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cita);
        }

        // GET: Citas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Citas.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cita cita = db.Citas.Find(id);
            db.Citas.Remove(cita);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
