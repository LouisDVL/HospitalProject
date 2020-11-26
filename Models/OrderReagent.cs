using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProject.Models
{
    public class OrderReagent
    {
        public int Id { get; set; } 

        public Reagent reagent { get; set; }

        [Required]
        public float AmountNeeded { get; set; }
    }
}
