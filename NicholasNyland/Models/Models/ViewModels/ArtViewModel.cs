using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NicholasNyland.Models.Models.ViewModels
{
    public class ArtViewModel
    {
        public IEnumerable<Art> Arts { get; set; }
        public IEnumerable<Exhibit> Exhibits { get; set; }
    }
}