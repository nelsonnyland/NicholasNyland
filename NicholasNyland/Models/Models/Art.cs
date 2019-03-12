using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NicholasNyland.Models
{
    public enum Medium
    {
        PAINTING,
        SCULPTURE,
        INSTALLATION
    }
    
    public class Art
    {
        [Key]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public Medium Type { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }

        public bool Equals(Art piece)
        {
            return this.Name == piece.Name &&
                   this.Date == piece.Date &&
                   this.Type == piece.Type;
        }
    }
}