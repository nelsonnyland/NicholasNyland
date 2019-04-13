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
            return View(ExhibitsDb.GetAllExhibits(db));
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
            exhibit.Gallery = ArtsDb.GetArtsByString(db, exhibit.ArtKeys);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection data)
        {
            if (ModelState.IsValid)
            {
                Exhibit ex = new Exhibit
                {
                    Name = data["Name"],
                    Date = Convert.ToDateTime(data["Date"]),
                    Location = data["Location"],
                    ArtKeys = data["Selects"],
                    Gallery = ArtsDb.GetArtsByString(db, data["Selects"])
                };

                if (!ExhibitsDb.HasExhibit(db, ex.Name))
                {
                    db.DbExhibit.Add(ex);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Name", "This name has been used already.");
                }
            }

            return View(data);
        }

        // GET: Exhibits/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhibit ex = db.DbExhibit.Find(id);
            if (ex == null)
            {
                return HttpNotFound();
            }
            
            ExhibitsViewModel vm = new ExhibitsViewModel
            {
                Name = ex.Name,
                Date = ex.Date,
                Location = ex.Location,
                ArtList = ArtsDb.GetCurrentArts_SelectListItems(db)
            };

            return View(vm);
        }

        // POST: Exhibits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection data)
        {
            if (ModelState.IsValid)
            {
                Exhibit ex = new Exhibit
                {
                    Name = data["Name"],
                    Date = Convert.ToDateTime(data["Date"]),
                    Location = data["Location"],
                    ArtKeys = data["Selects"],
                    Gallery = ArtsDb.GetArtsByString(db, data["Selects"])
                };
                
                db.Entry(ex).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(data);
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
