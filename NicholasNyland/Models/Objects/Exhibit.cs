using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NicholasNyland.Models
{
    public class Exhibit
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        private List<Art> Gallery { get; set; }
        
        public bool Compare(Exhibit ev)
        {
            return this.Name == ev.Name &&
                   this.Date == ev.Date &&
                   this.Location == ev.Location;
        }

        public List<Art> GetGallery()
        {
            return this.Gallery;
        }

        public void SetGallery(List<Art> gallery)
        {
            this.Gallery = gallery;
        }

        public bool HasPiece(Art piece)
        {
            return this.Gallery.Contains(piece);
        }

        public void AddPiece(Art piece)
        {
            this.Gallery.Add(piece);
        }

        public void RemovePiece(Art piece)
        {
            this.Gallery.Remove(piece);
        }
    }
}