using DynamicVML;
using DynamicVML.Extensions;
using HospitalProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProject.ViewModel
{
    public class NewOrderViewModel
    {
        public virtual DynamicList<OrderReagent> OrderReagents { get; set; } = new DynamicList<OrderReagent>();

        public string Action { get; set; }
    }
}
