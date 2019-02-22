using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NicholasNyland.Models
{
    public class Exhibit
    {
        string Name;
        DateTime Date;
        string Location;
        List<Art> Gallery;
        
        public Exhibit()
        {
            this.Name = "";
            this.Date = new DateTime();
            this.Location = "";
            this.Gallery = new List<Art>();
        }

        public Exhibit(string name,
                       DateTime date,
                       string location,
                       List<Art> gallery)
        {
            this.Name = name;
            this.Date = date;
            this.Location = location;
            this.Gallery = gallery;
        }

        public string GetName()
        {
            return this.Name;
        }

        public void SetName(string name)
        {
            this.Name = name;
        }

        public DateTime GetDate()
        {
            return this.Date;
        }

        public void SetDate(DateTime date)
        {
            this.Date = date;
        }

        public string GetLocation()
        {
            return this.Location;
        }

        public void SetLocation(string location)
        {
            this.Location = location;
        }

        public List<Art> GetGallery()
        {
            return this.Gallery;
        }

        public void SetGallery(List<Art> gallery)
        {
            this.Gallery = gallery;
        }

        /// <summary>
        /// Returns true if this Exhibit has this Art piece.
        /// </summary>
        /// <param name="piece"></param>
        /// <returns></returns>
        public bool HasPiece(Art piece)
        {
            return this.Gallery.Contains(piece);
        }

        /// <summary>
        /// Adds this Art piece to this Exhibit.
        /// </summary>
        /// <param name="piece"></param>
        public void AddPiece(Art piece)
        {
            this.Gallery.Add(piece);
        }
        
        /// <summary>
        /// Removes this piece from this Exhibit.
        /// </summary>
        /// <param name="piece"></param>
        public void RemovePiece(Art piece)
        {
            this.Gallery.Remove(piece);
        }

        /// <summary>
        /// Compares this Exhibit with the Exhbit given.
        /// </summary>
        /// <param name="ev"></param>
        /// <returns></returns>
        public bool Equals(Exhibit ev)
        {
            return this.Name == ev.Name &&
                   this.Date == ev.Date &&
                   this.Location == ev.Location;
        }
    }
}