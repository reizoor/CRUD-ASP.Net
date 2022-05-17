using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RegistroHorasPage.Models;

namespace RegistroHorasPage.Controllers
{
    public class RegistroHoraController : Controller
    {
        private RegistroHorasEntities db = new RegistroHorasEntities();

        // GET: RegistroHora
        public ActionResult Index()
        {
            var registroHoras = db.RegistroHoras.Include(r => r.Empresa);
            return View(registroHoras.ToList());
        }

        // GET: RegistroHora/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroHoras registroHoras = db.RegistroHoras.Find(id);
            if (registroHoras == null)
            {
                return HttpNotFound();
            }
            return View(registroHoras);
        }

        // GET: RegistroHora/Create
        public ActionResult Create()
        {
            ViewBag.IdCatEmpresa = new SelectList(db.Empresa, "IdCatEmpresa", "NombreEmpresa");
            return View();
        }

        // POST: RegistroHora/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdControlHora,FechaCaptura,Fecha,HorasTotales,IdCatEmpresa")] RegistroHoras registroHoras)
        {
            if (ModelState.IsValid)
            {
                db.RegistroHoras.Add(registroHoras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCatEmpresa = new SelectList(db.Empresa, "IdCatEmpresa", "NombreEmpresa", registroHoras.IdCatEmpresa);
            return View(registroHoras);
        }

        // GET: RegistroHora/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroHoras registroHoras = db.RegistroHoras.Find(id);
            if (registroHoras == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCatEmpresa = new SelectList(db.Empresa, "IdCatEmpresa", "NombreEmpresa", registroHoras.IdCatEmpresa);
            return View(registroHoras);
        }

        // POST: RegistroHora/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdControlHora,FechaCaptura,Fecha,HorasTotales,IdCatEmpresa")] RegistroHoras registroHoras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroHoras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCatEmpresa = new SelectList(db.Empresa, "IdCatEmpresa", "NombreEmpresa", registroHoras.IdCatEmpresa);
            return View(registroHoras);
        }

        // GET: RegistroHora/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroHoras registroHoras = db.RegistroHoras.Find(id);
            if (registroHoras == null)
            {
                return HttpNotFound();
            }
            return View(registroHoras);
        }

        // POST: RegistroHora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroHoras registroHoras = db.RegistroHoras.Find(id);
            db.RegistroHoras.Remove(registroHoras);
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
