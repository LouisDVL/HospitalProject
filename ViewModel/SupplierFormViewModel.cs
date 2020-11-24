using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProject.ViewModel
{
    public class SupplierFormViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name is to long")]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Location { get; set; }

        [Phone]
        public string Contact { get; set; }

        public string Action { get; set; }
    }
}
