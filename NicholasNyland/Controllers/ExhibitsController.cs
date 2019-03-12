using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NicholasNyland.Models;
using NicholasNyland.Models.Database;
using NicholasNyland.Models.Models.ViewModels;

namespace NicholasNyland.Controllers
{
    [Authorize]
    public class ExhibitsController : Controller
    {
        private ArtDb db = new ArtDb();

        // GET: Exhibits
        public ActionResult Index()
        {
            return View(db.DbExhibit.ToList());
        }

        // GET: Exhibits/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhibit exhibit = db.DbExhibit.Find(id);
            if (exhibit == null)
            {
                return HttpNotFound();
            }
            return View(exhibit);
        }

        // GET: Exhibits/Create
        [HttpGet]
        public ActionResult Create()
        {
            ExhibitsViewModel vm = new ExhibitsViewModel();
            vm.ArtList = ArtsDb.GetCurrentArts_SelectListItems(db);
            
            return View(vm);
        }

        // POST: Exhibits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        // [Bind(Include = "Name,Date,Location,Gallery")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Date,Location,Selects")]
                                    ExhibitsViewModel model)
        {
            if (ModelState.IsValid)
            {
                Exhibit ex = new Exhibit()
                {
                    Name = model.Name,
                    Date = model.Date,
                    Location = model.Location,
                    Gallery = ArtsDb.GetArtsBySelectListItems(db, model.Selects)
                };

                db.DbExhibit.Add(ex);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Exhibits/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhibit exhibit = db.DbExhibit.Find(id);
            if (exhibit == null)
            {
                return HttpNotFound();
            }
            return View(exhibit);
        }

        // POST: Exhibits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Date,Location")] Exhibit exhibit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exhibit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exhibit);
        }

        // GET: Exhibits/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhibit exhibit = db.DbExhibit.Find(id);
            if (exhibit == null)
            {
                return HttpNotFound();
            }
            return View(exhibit);
        }

        // POST: Exhibits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Exhibit exhibit = db.DbExhibit.Find(id);
            db.DbExhibit.Remove(exhibit);
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
