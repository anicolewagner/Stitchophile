using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlossMVCApp.Models
{
    public class Floss
    {
        public int FlossId { get; set; }

        [Required(ErrorMessage = "Number required")]
        [DisplayName("Number")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Color required")]
        [DisplayName("Color")]
        public string Color { get; set; }

        public Company Company { get; set; }
        public int CompanyId { get; set; }

        [Range(1, (double)decimal.MaxValue, ErrorMessage = "value should be between{1} and {2}.")]
        public decimal Skein { get; set; }
        public string Comment { get; set; }
    }
}