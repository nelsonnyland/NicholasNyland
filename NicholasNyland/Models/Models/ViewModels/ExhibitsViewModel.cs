using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NicholasNyland.Models.Models.ViewModels
{
    //[Bind(Include = "Name,Date,Location,Selects")]
    public class ExhibitsViewModel
    {
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public IEnumerable<SelectListItem> ArtList { get; set; }
        public IEnumerable<SelectListItem> Selects { get; set; }
    }
}