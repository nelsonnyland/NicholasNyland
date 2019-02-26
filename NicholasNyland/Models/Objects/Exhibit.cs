using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NicholasNyland.Models
{
    [Table("Exhibits")]
    public class Exhibit
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public List<Art> Gallery { get; set; }        

        public bool Equals(Exhibit ev)
        {
            return this.Name == ev.Name &&
                   this.Date == ev.Date &&
                   this.Location == ev.Location;
        }
    }
}