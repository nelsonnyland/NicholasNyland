using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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

        public static Art GetArt(ArtDb db, string name)
        {
            return db.DbArt.Find(name);
        }

        public static IEnumerable<Art> GetAllPaintings(ArtDb db)
        {
            return db.DbArt.Where(p => p.Type == Medium.PAINTING);
        }

        public static IEnumerable<Art> GetAllSculptures(ArtDb db)
        {
            return db.DbArt.Where(p => p.Type == Medium.SCULPTURE);
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