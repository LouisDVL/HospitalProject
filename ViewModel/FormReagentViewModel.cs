using HospitalProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProject.ViewModel
{
    public class FormReagentViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name is to long.")]
        public string Name { get; set; }

        [Required]
        [Range(1, 5)]
        public int Alert { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [Range(1, 2, ErrorMessage = "Please select between Solid or Liquid.")]
        [DisplayName("State")]
        public int stateId { get; set; }

        [Required]
        [VolumeAttribute]
        public float Volume { get; set; }

        [Required]
        [RegularExpression(@"^\d*[1-9]\d*$", ErrorMessage = "Max Volume cannot be set to 0.")]
        public float MaxVolume { get; set; }

        [Required]
        [DisplayName("Supplier")]
        public int SupplierID { get; set; }

        public IEnumerable<SelectListItem> SuppliersChoices { get; set; }

        public string Action { get; set; }


    }
}
