using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CorsoDataModel.Models;

namespace CorsoDataModel.Controllers
{
    public class ImpiegatoController : Controller
    {
        //private Database1Entities db = new Database1Entities();

        //
        // GET: /Impiegato/
        public ActionResult Index()
        {
          List<Impiegato> model = new List<Impiegato>(); 
          using (Database1Entities db = new Database1Entities())
          {
            model = db.Impiegati.ToList();
          }
         
          return View(model);

            //return View( db.Impiegati.ToList() );
        }
	}
}