using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CorsoCF.Models;
using CorsoCF.Models.ViewModels;



namespace CorsoCF.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Benvenuto benvenuto = new Benvenuto();
                benvenuto.Data = DateTime.Now;
                benvenuto.NumeroAziende = db.Aziende.Count();
                benvenuto.NumeroImpiegati = db.Impiegati.Count();
                return View(benvenuto);
            }
        }
    }
}