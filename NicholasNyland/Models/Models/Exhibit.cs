using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NicholasNyland.Models
{
    [Table("Exhibits")]
    public class Exhibit
    {
        [Key]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string ArtKeys { get; set; }
        public IList<Art> Gallery { get; set; }        
    }
}