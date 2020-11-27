using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProject.Models
{
    public class OrderReagent
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        public int reagentId { get; set; }

        public Reagent reagent { get; set; }

        [Required]
        public float AmountNeeded { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> ReagentChoices { get; set; }

    }
}
