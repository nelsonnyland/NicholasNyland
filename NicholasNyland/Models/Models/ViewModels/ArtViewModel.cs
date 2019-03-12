using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NicholasNyland.Models.Models.ViewModels
{
    public class ArtViewModel
    {
        public IDictionary<DateTime, string> Exhibits { get; set; }
        public IDictionary<DateTime, Medium> Paintings { get; set; }
        public IDictionary<DateTime, Medium> Sculptures { get; set; }
        public IEnumerable<Art> Gallery { get; set; }
    }
}