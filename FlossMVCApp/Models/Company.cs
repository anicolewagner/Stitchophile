using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FlossMVCApp.Models
{
    public class Company
    {
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Company required")]
        [DisplayName("Company")]
        public string Name { get; set; }

        public ICollection<Floss> Flosses { get; set; }

    }
}
