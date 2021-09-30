using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventdotNetFrameWork.Models;

namespace EventdotNetFrameWork.Controllers
{
    public class EventsController : Controller
    {
        private mContext db = new mContext();
       
        
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }
      

        public ActionResult GetEvents()
        {
         
            IEnumerable<Event> tenEvents = db.Events.Where(obj=>obj.StartDate<=DateTime.Now &&  obj.EndDate >=DateTime.Now).Take(10);
            return Json(new { data = tenEvents }, JsonRequestBehavior.AllowGet);
        }

 
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }


        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
    
        public ActionResult Create(Event  ev, HttpPostedFileBase file)
        {
            if (!string.IsNullOrEmpty(ev.Title) && !string.IsNullOrEmpty(ev.StartDate.ToString()) && !string.IsNullOrEmpty(ev.EndDate.ToString()) && !string.IsNullOrEmpty(ev.City) && !string.IsNullOrEmpty(ev.Country)) {

                if (file != null && file.ContentLength > 0&& file.ContentLength < 4194304)
                {
                    string imageName = Path.GetFileNameWithoutExtension(file.FileName);
                     string extension = Path.GetExtension(file.FileName);
                     imageName = imageName + DateTime.Now.ToString("ddssmm") + extension;
                    ev.Img = imageName;
                    string path = Path.Combine(Server.MapPath("~/Images"), imageName);

                    file.SaveAs(path);
                }

                db.Events.Add(ev);
                db.SaveChanges();
                return RedirectToAction("Index");

            }


            return View(ev);
        }
       

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,Title,StartDate,EndDate,Country,City,Img,Description")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

 
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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


        public   static List<SelectListItem> Countries = new List<SelectListItem>() {
        new SelectListItem(){Text="Egypt",Value="Egypt"},
        new SelectListItem(){Text="USA",Value="USA"},
        new SelectListItem(){Text="Uk",Value="London"}
        };
        public static List<SelectListItem> Cities = new List<SelectListItem>() {
        new SelectListItem(){Text="CityA",Value="CityA"},
        new SelectListItem(){Text="CityB",Value="CityB"},
        new SelectListItem(){Text="CityC",Value="CityC"}
        };




    }



}
