using HospitalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProject.ViewModel
{
    public class SupplierGetViewModel
    {
        public Supplier Supplier { get; set; }

        public IEnumerable<Reagent> Reagents { get; set; }
    }
}
