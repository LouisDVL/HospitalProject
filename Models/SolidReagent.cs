using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.Models
{
    public class SolidReagent
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AlertCode { get; set; }
        public string LocationInLab { get; set; }
        //This will be in grams or mililitres
        public int currentVolume { get; set; }
        public int MaxVolume { get; set; }

        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }
    }
}
