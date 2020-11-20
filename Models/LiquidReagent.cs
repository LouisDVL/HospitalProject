using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.Models
{
    public class LiquidReagent
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int AlertCode { get; set; }

        [Required]
        public string LocationInLab { get; set; }

        //This will be in grams or mililitres
        [Required]
        public int currentVolume { get; set; }

        [Required]
        public int MaxVolume { get; set; }

        [Required]
        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }

    }
}
