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
            vm.Paintings = ArtsDb.GetAllPaintings(db);
            vm.Sculptures = ArtsDb.GetAllSculptures(db);

            // Gallery
            if (id != null)
            {
                Exhibit show = ExhibitsDb.GetExhibit(db, id);
                if (show != null)
                {
                    vm.Gallery = show.Gallery;
                }
                else
                {
                    vm.Gallery = ArtsDb.GetArtsByName(db, id);
                }
            }
            else
            {
                Exhibit show = ExhibitsDb.GetNews(db);
                if (show != null)
                {
                    vm.Gallery = show.Gallery;
                }
            }

            return View(vm);
        }

        public ActionResult News()
        {
            return View(ExhibitsDb.GetAllExhibits(db));
        }
    }
}