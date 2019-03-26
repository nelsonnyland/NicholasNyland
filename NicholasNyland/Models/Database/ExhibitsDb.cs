using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NicholasNyland.Models.Database
{
    public static class ExhibitsDb
    {
        /// <summary>
        /// Exhibits are ordered in descending order, enabling first element
        /// access to latest Exhibit by date. First element is news.
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static IEnumerable<Exhibit> GetAllExhibits(ArtDb db)
        {
            IEnumerable<Exhibit> ex = db.DbExhibit.OrderByDescending(e => e.Date).ToList();
            return FillExhibits(db, ex);
        }

        /// <summary>
        /// Gets Exhibit by name.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Exhibit GetExhibit(ArtDb db, string name)
        {
            Exhibit ex = db.DbExhibit.Find(name);            
            return FillExhibit(db, ex);
        }

        /// <summary>
        /// Returns latest Exhibit by date.
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static Exhibit GetNews(ArtDb db)
        {
            Exhibit ex = db.DbExhibit.OrderByDescending(e => e.Date).FirstOrDefault();
            if (ex != null)
            {
                return FillExhibit(db, ex);
            }
            return null;
        }

        /// <summary>
        /// Gets a key-value pair of each Exhibit date and name in descending order.
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static IDictionary<DateTime, string> GetExhibitMap(ArtDb db)
        {
            IEnumerable<Exhibit> exhibits = db.DbExhibit.OrderByDescending(e => e.Date).ToList();
            IDictionary<DateTime, string> pair =
                new Dictionary<DateTime, string>();
            foreach (var ex in exhibits)
            {
                pair.Add(ex.Date, ex.Name);
            }
            return pair;
        }

        /// <summary>
        /// Fills a list of Exhibit with an art gallery.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="exhibits"></param>
        /// <returns></returns>
        public static IEnumerable<Exhibit> FillExhibits(ArtDb db, 
            IEnumerable<Exhibit> exhibits)
        {
            foreach (var item in exhibits)
            {
                item.Gallery = ArtsDb.GetArtsByString(db, item.ArtKeys);
            }
            return exhibits;
        }

        /// <summary>
        /// Fills an Exhibit with an art gallery.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="exhibit"></param>
        /// <returns></returns>
        public static Exhibit FillExhibit(ArtDb db, Exhibit exhibit)
        {
            if (exhibit != null)
            {
                exhibit.Gallery = ArtsDb.GetArtsByString(db, exhibit.ArtKeys);
            }
            return exhibit;
        }

        public static bool HasExhibit(ArtDb db, string name)
        {
            Exhibit ex = db.DbExhibit.Find(name);
            if (ex is null)
            {
                return false;
            }
            return true;
        }

        public static void AddExhibits(ArtDb db, IEnumerable<Exhibit> exhibits)
        {
            db.DbExhibit.AddRange(exhibits);
        }

        public static void DeleteExhibit(ArtDb db, Exhibit exhibit)
        {
            db.DbExhibit.Remove(exhibit);
            db.SaveChanges();
        }        
    }
}