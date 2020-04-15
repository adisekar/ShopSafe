using ShopSafe_Web.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopSafe_Web.Models
{
    public class SelectVM
    {
        [Display(Name = "Select your Store")]
        public List<Store> Stores { get; set; }

        [Display(Name = "Select your store Location")]
        public List<Location> Locations { get; set; }

        public int StoreId { get; set; }
        public int LocationId { get; set; }
    }
}