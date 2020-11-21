using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProject.Models
{
    public class Reagent
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Alert { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public State State { get; set; }

        [Required]
        public int stateId { get; set; }

        [Required]
        public int Volume { get; set; }

        [Required]
        public int MaxVolume { get; set; }

        [Required]
        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }
    }
}
