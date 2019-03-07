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

        public ActionResult Index()
        {
            // Art and Exhibits
            ArtViewModel vm = new ArtViewModel();
            vm.Arts = ArtsDb.GetAllArts(db);
            vm.Exhibits = ExhibitsDb.GetAllExhibits(db);
            
            // news data
            Exhibit ex = ExhibitsDb.GetNews(db);
            ViewBag.NewsPath = ex.Gallery.Last().Path;
            ViewBag.NewsName = ex.Name;
            
            return View(vm);
        }

        public ActionResult News()
        {
            return View();
        }
    }
}