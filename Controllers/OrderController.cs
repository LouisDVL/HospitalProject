using DynamicVML;
using DynamicVML.Extensions;
using HospitalProject.Data;
using HospitalProject.Models;
using HospitalProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProject.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Index
        [HttpGet]
        public IActionResult Index()
        {
            var Orders = _context.Orders.ToList();
            return View(Orders);
        }

        //Create Route Get
        [HttpGet]
        public IActionResult NewOrder()
        {
            NewOrderViewModel viewModel = new NewOrderViewModel
            {
                Action = "NewOrder"
            };
            return View("FormOrder", viewModel);
        }

        public IActionResult AddReagent(AddNewDynamicItem parameters)
        {
            var reagentChoices = _context.Reagents.Select(r => new { r.Id, r.Name }).ToList();
            var newOrderReagent = new OrderReagent()
            {
                ReagentChoices = new SelectList(reagentChoices, "Id", "Name")
            };

            return this.PartialView(newOrderReagent, parameters);
        }
    }
}
