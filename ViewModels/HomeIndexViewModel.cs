using HospitalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Reagent> Reagents { get; set; }
    }
}
