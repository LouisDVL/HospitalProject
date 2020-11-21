using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.Models
{
    public class Supplier
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Location { get; set; }

        public string Contact { get; set; }
    }
}
