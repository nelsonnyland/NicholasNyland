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
            return db.DbExhibit.OrderByDescending(e => e.Date).ToList();
        }

        /// <summary>
        /// Gets Exhibit by name.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Exhibit GetExhibit(ArtDb db, string name)
        {
            return db.DbExhibit.Find(name);
        }

        /// <summary>
        /// Returns latest Exhibit by date.
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static Exhibit GetNews(ArtDb db)
        {
            return db.DbExhibit.OrderByDescending(e => e.Date).FirstOrDefault();
        }

        public static void AddExhibits(ArtDb db, IEnumerable<Exhibit> exhibits)
        {
            db.DbExhibit.AddRange(exhibits);
        }

        public static void UpdateExhibit(ArtDb db, Exhibit exhibit)
        {
            db.Entry(exhibit).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void DeleteExhibit(ArtDb db, Exhibit exhibit)
        {
            db.DbExhibit.Remove(exhibit);
            db.SaveChanges();
        }
    }
}