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

        
        public string Name { get; set; }

        
        public int Alert { get; set; }

        
        public string Location { get; set; }

        
        public State State { get; set; }

        
        public int stateId { get; set; }

        //This will be in grams or mililitres
        
        public int Volume { get; set; }

        
        public int MaxVolume { get; set; }

        
        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }
    }
}
