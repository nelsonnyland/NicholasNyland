using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NicholasNyland.Models.Models.ViewModels
{
    public class AccountHomeViewModel
    {
        [Display(Name = "User Accounts")]
        public int NumAccounts { get; set; }
        [Display(Name = "Art")]
        public int NumArt { get; set; }
        [Display(Name = "Exhibits")]
        public int NumExhibits { get; set; }
    }
}