using MVCAuthentitification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAuthentitification.Controllers
{
    public class RentController : Controller
    {
        IzdavanjeKonzolaEntities db = new IzdavanjeKonzolaEntities();


        // GET: /Rent/
        public ActionResult Index()
        {



            var result = (from r in db.Rents
                          join c in db.Konzolas on r.modelKonzole equals c.model

                          select new RentailViewModel
                          {
                              idRent = r.idRent,
                              modelKonzole=r.modelKonzole,
                              nazivIgrice=r.nazivIgrice,
                              datumod=r.datumod,
                              datumdo=r.datumdo,
                              cena=r.cena
                          }).ToList() ;


            return View(result);
        }

        [HttpGet]
        public ActionResult Getkonzola()
        {
            
                var konzola = db.Konzolas.ToList();
                return Json(konzola, JsonRequestBehavior.AllowGet);

            
        }
        [HttpGet]
        public ActionResult Getigrica()
        {

            var igrica = db.Igricas.ToList();
            return Json(igrica, JsonRequestBehavior.AllowGet);


        }








        [HttpPost]
        public ActionResult Save(Rent rent)

        {
            if(ModelState.IsValid)
            {
                db.Rents.Add(rent);

                var konzole = db.Konzolas.SingleOrDefault(e => e.model == rent.modelKonzole);
                    if(konzole == null)
                    return HttpNotFound("Konzola is not valid");

                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(rent);
        }
    }
}