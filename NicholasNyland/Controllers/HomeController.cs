using NicholasNyland.Models;
using NicholasNyland.Models.Database;
using NicholasNyland.Models.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NicholasNyland.Controllers
{
    public class HomeController : Controller
    {
        ArtDb db = new ArtDb();

        public ActionResult Index(string id)
        {
            // news data
            Exhibit ex = ExhibitsDb.GetNews(db);
            if (ex != null)
            {
                ViewBag.NewsPath = ex.Gallery.Last().Path;
                ViewBag.NewsName = ex.Name;
            }

            // Exhibits
            ArtViewModel vm = new ArtViewModel();            
            vm.Exhibits = ExhibitsDb.GetExhibitMap(db);
            vm.Paintings = ArtsDb.GetPaintingMap(db);
            vm.Sculptures = ArtsDb.GetSculptureMap(db);

            // Gallery
            if (id != null)
            {
                Exhibit show = ExhibitsDb.GetExhibit(db, id);
                vm.Gallery = show.Gallery;
            }
            else
            {
                Exhibit show = ExhibitsDb.GetNews(db);
                vm.Gallery = show.Gallery;
            }

            return View(vm);
        }

        [ActionName("Gallery")]
        public ActionResult Index(Art id)
        {
            // news data
            Exhibit ex = ExhibitsDb.GetNews(db);
            if (ex != null)
            {
                ViewBag.NewsPath = ex.Gallery.Last().Path;
                ViewBag.NewsName = ex.Name;
            }

            // Exhibits, Paintings, Sculptures
            ArtViewModel vm = new ArtViewModel();
            vm.Exhibits = ExhibitsDb.GetExhibitMap(db);
            vm.Paintings = ArtsDb.GetPaintingMap(db);
            vm.Sculptures = ArtsDb.GetSculptureMap(db);

            // Gallery
            if (id != null)
            {
                vm.Gallery = ArtsDb.GetArtsByDate(db, id);
            }
            else
            {
                Exhibit show = ExhibitsDb.GetNews(db);
                vm.Gallery = show.Gallery;
            }

            return View(vm);
        }

        public ActionResult News()
        {
            return View();
        }
    }
}