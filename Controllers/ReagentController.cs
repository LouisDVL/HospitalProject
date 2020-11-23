using HospitalProject.Data;
using HospitalProject.Models;
using HospitalProject.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProject.Controllers
{
    public class ReagentController : Controller
    {
        private readonly ApplicationDbContext _context;


        public ReagentController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
        }

        //Create
        [HttpGet]
        public IActionResult NewReagent()
        {
            var Suppliers = _context.Suppliers.Select(r => new { r.ID, r.Name }).ToList();
            
            NewReagentViewModel viewModel = new NewReagentViewModel
            {
                Reagent = new Reagent(),
                Suppliers = new SelectList(Suppliers, "ID", "Name")
            };
            return View(viewModel);
        }

        //Read
        [HttpGet]
        public IActionResult GetReagent(int id)
        {
            var Reagent = _context.Reagents.Where(r => r.Id == id)
                .Include(r => r.Supplier)
                .Include(r => r.State)
                .FirstOrDefault();
            return View(Reagent);
        }

        //Create post
        [HttpPost]
        public IActionResult NewReagent(Reagent reagent)
        {
            if(!ModelState.IsValid)
            {
                var Suppliers = _context.Suppliers.Select(r => new { r.ID, r.Name }).ToList();
                NewReagentViewModel viewModel = new NewReagentViewModel
                {
                    Reagent = reagent,
                    Suppliers = new SelectList(Suppliers, "ID", "Name")
                };
                return View(viewModel);
            }
            _context.Reagents.Add(reagent);
            _context.SaveChanges();
            var routeValue = new RouteValueDictionary(new { action = "Index", controller = "Home" });
            return RedirectToRoute(routeValue);
        }
    }
}
