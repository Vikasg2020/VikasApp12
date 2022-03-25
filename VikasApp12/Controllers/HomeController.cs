using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VikasApp12.DBEntity;
using VikasApp12.Models;

namespace VikasApp12.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            StudBCAEntities sb= new StudBCAEntities();

            var re = sb.studs.ToList();

            List<DataModel> dm = new List<DataModel>();

            foreach(var item in re)
            {
                dm.Add(new DataModel
                {
                    id=item.id,
                    name = item.name,
                    email= item .email,
                    depart= item.depart

                }) ;
            }



            return View(dm);
        }
        [HttpGet]
        public ActionResult AddStud()
        {


            return View();


        }
        [HttpPost]
        public ActionResult AddStud(DataModel dm)
        {

            StudBCAEntities sb= new StudBCAEntities();
            stud dat = new stud();
            dat.id = dm.id;
            dat.name = dm.name;
            dat.email = dm.email;
            dat.depart = dm.depart;
            if (dat.id == 0)
            {
                sb.studs.Add(dat);
                sb.SaveChanges();
            }
            else
            {
                sb.Entry(dat).State = System.Data.Entity.EntityState.Modified;
                sb.SaveChanges();
            }
           

            return RedirectToAction("Index","Home");

        }
        public ActionResult Edit(int id)
        {
            DataModel dm = new DataModel();

            StudBCAEntities abe = new StudBCAEntities();
            var Editi = abe.studs.Where(x => x.id == id).First();

            dm.id = Editi.id;
            dm.name = Editi.name;
            dm.email = Editi.email;
            dm.depart = Editi.depart;



            return View("AddStud", dm);
        }

        public ActionResult Delete(int id)
        {
            StudBCAEntities de = new StudBCAEntities();

            var dele = de.studs.Where(x => x.id == id).First();
            de.studs.Remove(dele);
            de.SaveChanges();

            return RedirectToAction("Index");


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