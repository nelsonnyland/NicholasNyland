using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NicholasNyland.Models.Database
{
    public static class ArtsDb
    {
        /// <summary>
        /// Get all Art starting with most recent at index 0.
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static IEnumerable<Art> GetAllArts(ArtDb db)
        {
            return db.DbArt.OrderByDescending(e => e.Date).ToList();
        }

        /// <summary>
        /// Gets specific Art by name.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Art GetArt(ArtDb db, string name)
        {
            return db.DbArt.Find(name);
        }

        /// <summary>
        /// Gets all paintings from Art db and sorts them into a key value pair by date.
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static IDictionary<DateTime, IEnumerable<Art>> GetAllPaintings(ArtDb db)
        {
            IEnumerable<Art> paintings = db.DbArt.Where(p => p.Type == Medium.PAINTING);
            
            IDictionary<DateTime, IEnumerable<Art>> set = 
                new Dictionary<DateTime, IEnumerable<Art>>();
            
            DateTime date = new DateTime();
            
            foreach (var painting in paintings)
            {
                if (painting.Date.Year != date.Year)
                {
                    List<Art> paint = new List<Art>();
                    IEnumerable<Art> art = new List<Art>();
                    paint.Add(painting);
                    art = paint;
                    set.Add(painting.Date, art);
                    date = painting.Date;
                }
                else
                {
                    IEnumerable<Art> art = set[date];
                    List<Art> paint = (List<Art>)art;
                    paint.Add(painting);
                    art = paint;
                    set[date] = art;
                }
            }
            
            return set;
        }

        /// <summary>
        /// Gets all painting dates from Art db and sorts them into a key value pair by date.
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static IDictionary<DateTime, Medium> GetPaintingMap(ArtDb db)
        {
            IEnumerable<Art> paintings = db.DbArt.OrderByDescending(e => e.Date)
                                                 .Where(p => p.Type == Medium.PAINTING);

            IDictionary<DateTime, Medium> set =
                new Dictionary<DateTime, Medium>();

            DateTime date = new DateTime();

            foreach (var painting in paintings)
            {
                if (painting.Date.Year != date.Year)
                {
                    set.Add(painting.Date, Medium.PAINTING);
                    date = painting.Date;
                }
            }

            return set;
        }

        /// <summary>
        /// Gets all sculptures from Art db and sorts them into a key value pair by date.
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static IDictionary<DateTime, IEnumerable<Art>> GetAllSculptures(ArtDb db)
        {
            IEnumerable<Art> sculptures = db.DbArt.OrderByDescending(e => e.Date)
                                                  .Where(p => p.Type == Medium.SCULPTURE);
            
            IDictionary<DateTime, IEnumerable<Art>> set = 
                new Dictionary<DateTime, IEnumerable<Art>>();
            
            DateTime date = new DateTime();
            
            foreach (var sculpture in sculptures)
            {
                if (sculpture.Date.Year != date.Year)
                {
                    List<Art> sculpt = new List<Art>();
                    IEnumerable<Art> art = new List<Art>();
                    sculpt.Add(sculpture);
                    art = sculpt;
                    set.Add(sculpture.Date, art);
                    date = sculpture.Date;
                }
                else
                {
                    IEnumerable<Art> art = set[date];
                    List<Art> sculpt = (List<Art>)art;
                    sculpt.Add(sculpture);
                    art = sculpt;
                    set[date] = art;
                }
            }
            
            return set;
        }

        /// <summary>
        /// Gets all sculpture dates from Art db and sorts them into a key value pair by date.
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static IDictionary<DateTime, Medium> GetSculptureMap(ArtDb db)
        {
            IEnumerable<Art> sculptures = db.DbArt.OrderByDescending(e => e.Date)
                                                  .Where(p => p.Type == Medium.SCULPTURE);

            IDictionary<DateTime, Medium> set =
                new Dictionary<DateTime, Medium>();

            DateTime date = new DateTime();

            foreach (var sculpt in sculptures)
            {
                if (sculpt.Date.Year != date.Year)
                {
                    set.Add(sculpt.Date, Medium.SCULPTURE);
                    date = sculpt.Date;
                }
            }

            return set;
        }

        /// <summary>
        /// Gets a list of art matching date and type.
        /// </summary>
        /// <param name="art"></param>
        /// <returns></returns>
        public static IEnumerable<Art> GetArtsByDate(ArtDb db, Art art)
        {
            int date = art.Date.Year;
            Medium type = art.Type;
            IEnumerable<Art> arts = db.DbArt.Where(a => a.Date.Year == date)
                                            .Where(a => a.Type == type);
            return arts;
        }

        /// <summary>
        /// Gets a list of art by current year starting alphabetically.
        /// Returns a List<SelectListItem> for ListBox in view.
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<SelectListItem> GetCurrentArts_SelectListItems(ArtDb db)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            IEnumerable<Art> arts = db.DbArt.OrderBy(a => a.Name);
            foreach (var piece in arts)
            {
                items.Add(new SelectListItem
                {
                    Text = piece.Name
                });
            }
            return items;
        }

        /// <summary>
        /// Gets a list of art by selected list items. Returns a List<Art>.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="selects"></param>
        /// <returns></returns>
        public static List<Art> GetArtsBySelectListItems(ArtDb db, IEnumerable<SelectListItem> selects)
        {
            List<string> names = (List<string>)selects.Select(a => a.Text);
            List<Art> arts = (List<Art>)db.DbArt.Where(a => names.Contains(a.Name));
            return arts;
        }

        /// <summary>
        /// Gets a list of art by comma-separated string items. Returns a List<Art>.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="selects"></param>
        /// <returns></returns>
        public static IList<Art> GetArtsByString(ArtDb db, string selects)
        {
            string[] names = selects.Split(',');
            IEnumerable<Art> iArts = db.DbArt.Where(a => names.Contains(a.Name));
            IList<Art> arts = new List<Art>(iArts);            
            return arts;
        }

        public static void AddArts(ArtDb db, IEnumerable<Art> arts)
        {
            db.DbArt.AddRange(arts);
        }

        public static void UpdateArt(ArtDb db, Art art)
        {
            db.Entry(art).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void DeleteArt(ArtDb db, Art art)
        {
            db.DbArt.Remove(art);
            db.SaveChanges();
        }
    }
}