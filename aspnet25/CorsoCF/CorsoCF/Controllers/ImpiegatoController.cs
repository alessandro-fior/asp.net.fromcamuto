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
    public class ImpiegatoController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: /Impiegato/
        public ActionResult Index()
        {
            var impiegati = db.Impiegati.Include(i => i.Azienda);
            return View(impiegati.ToList());
        }

        // GET: /Impiegato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Impiegato impiegato = db.Impiegati.Find(id);
            if (impiegato == null)
            {
                return HttpNotFound();
            }
            return View(impiegato);
        }

        // GET: /Impiegato/Create
        public ActionResult Create()
        {
            ViewBag.FKaziendaID = new SelectList(db.Aziende, "aziendaID", "Nome");
            return View();
        }

        // POST: /Impiegato/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ImpiegatoID,Nome,Cognome,Email,Livello,FKaziendaID")] Impiegato impiegato)
        {
            if (ModelState.IsValid)
            {
                db.Impiegati.Add(impiegato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FKaziendaID = new SelectList(db.Aziende, "aziendaID", "Nome", impiegato.FKaziendaID);
            return View(impiegato);
        }

        // GET: /Impiegato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Impiegato impiegato = db.Impiegati.Find(id);
            if (impiegato == null)
            {
                return HttpNotFound();
            }
            ViewBag.FKaziendaID = new SelectList(db.Aziende, "aziendaID", "Nome", impiegato.FKaziendaID);
            return View(impiegato);
        }

        // POST: /Impiegato/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ImpiegatoID,Nome,Cognome,Email,Livello,FKaziendaID")] Impiegato impiegato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(impiegato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FKaziendaID = new SelectList(db.Aziende, "aziendaID", "Nome", impiegato.FKaziendaID);
            return View(impiegato);
        }

        // GET: /Impiegato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Impiegato impiegato = db.Impiegati.Find(id);
            if (impiegato == null)
            {
                return HttpNotFound();
            }
            return View(impiegato);
        }

        // POST: /Impiegato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Impiegato impiegato = db.Impiegati.Find(id);
            db.Impiegati.Remove(impiegato);
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
