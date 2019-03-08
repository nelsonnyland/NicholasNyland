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

            // Exhibits, Paintings, Sculptures
            ArtViewModel vm = new ArtViewModel();            
            vm.Exhibits = ExhibitsDb.GetAllExhibits(db);
            vm.Paintings = ArtsDb.GetAllPaintings(db);
            vm.Sculptures = ArtsDb.GetAllSculptures(db);
            
            // Gallery
            Exhibit galex = ExhibitsDb.GetExhibit(db, id);
            vm.Gallery = galex.Gallery;

            return View(vm);
        }

        public ActionResult News()
        {
            return View();
        }
    }
}