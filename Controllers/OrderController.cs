using HospitalProject.Data;
using HospitalProject.Models;
using HospitalProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
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
            var Orders = _context.Orders
                .Include(order => order.ReagentsNeeded)
                    .ThenInclude(reagentsNeeded => reagentsNeeded.reagent)
                .ToList();
            return View(Orders);
        }

        //Create Route Get
        [HttpGet]
        public IActionResult NewOrder()
        {
            var reagentsNeeded = new List<OrderReagent>();
            NewOrderViewModel viewModel = new NewOrderViewModel
            {
                ReagentsNeeded = reagentsNeeded
            };
            return View(viewModel);
        }
    }
}
