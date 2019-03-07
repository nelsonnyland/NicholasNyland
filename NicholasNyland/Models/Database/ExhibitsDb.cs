using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NicholasNyland.Models.Database
{
    public static class ExhibitsDb
    {
        public static IEnumerable<Exhibit> GetAllExhibits(ArtDb db)
        {
            return db.DbExhibit.ToList();
        }

        public static Exhibit GetExhibit(ArtDb db, string name)
        {
            return db.DbExhibit.Find(name);
        }

        public static Exhibit GetNews(ArtDb db)
        {
            return (Exhibit)from Exhibits in db.DbExhibit
                            group Exhibits by Exhibits.Date into e
                            select e.OrderByDescending(d => d.Date).FirstOrDefault();                            
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