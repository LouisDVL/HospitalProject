using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProject.Models
{
    public class Orders
    {
        public int Id { get; set; }

        public List<OrderReagent> ReagentsNeeded { get; set; }
    }
}
