using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CorsoCF.Models;

namespace CorsoCF.Controllers
{
    public class AziendaController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: /Azienda/
        public ActionResult Index()
        {
            return View(db.Aziende.ToList());
        }

        // GET: /Azienda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Azienda azienda = db.Aziende.Find(id);
            if (azienda == null)
            {
                return HttpNotFound();
            }
            return View(azienda);
        }

        // GET: /Azienda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Azienda/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="aziendaID,Nome,Telefono")] Azienda azienda)
        {
            if (ModelState.IsValid)
            {
                db.Aziende.Add(azienda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(azienda);
        }

        // GET: /Azienda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Azienda azienda = db.Aziende.Find(id);
            if (azienda == null)
            {
                return HttpNotFound();
            }
            return View(azienda);
        }

        // POST: /Azienda/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="aziendaID,Nome,Telefono")] Azienda azienda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(azienda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(azienda);
        }

        // GET: /Azienda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Azienda azienda = db.Aziende.Find(id);
            if (azienda == null)
            {
                return HttpNotFound();
            }
            return View(azienda);
        }

        // POST: /Azienda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Azienda azienda = db.Aziende.Find(id);
            db.Aziende.Remove(azienda);
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
