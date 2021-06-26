using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CorsoAuth.Models;
using System.Web.Security;

namespace CorsoAuth.Controllers
{
    public class UtenteController : Controller
    {
        // GET: Utente
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UtenteLoginModel utente)
        {
            if (ModelState.IsValid)
            {
                string username = IsValid(utente.Email, utente.Password);
                if (username != String.Empty)
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Dati non corretti.");
                }
            }

            return View(utente);
        }

        [HttpGet]
        public ActionResult Registrazione()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrazione(UtenteCreateModel utente)
        {

            if (ModelState.IsValid)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    var crypto = new SimpleCrypto.PBKDF2();
                    string encPassword = crypto.Compute(utente.Password);

                    Utente nuovoUtente = db.Utenti.Create();
                    nuovoUtente.Email = utente.Email;
                    nuovoUtente.Password = encPassword;
                    nuovoUtente.PasswordSalt = crypto.Salt;
                    nuovoUtente.Username = utente.Username;
                    nuovoUtente.UserID = Guid.NewGuid();

                    db.Utenti.Add(nuovoUtente);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            
            return View(utente);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");

        }


        private string IsValid(string email, string password)
        {
            string username = String.Empty;
            var crypto = new SimpleCrypto.PBKDF2();

            using (DatabaseContext db = new DatabaseContext())
            {
                Utente utente = 
                    db.Utenti.FirstOrDefault(u => u.Email == email);
                if (utente != null)
                {
                    if (utente.Password == 
                        crypto.Compute(password, utente.PasswordSalt))
                    {
                        username = utente.Username;
                    }
                }
            }
            return username;
        }


    }
}