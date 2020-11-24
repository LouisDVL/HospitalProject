using AutoMapper;
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
        private readonly IMapper _mapper;

        public ReagentController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Create
        [HttpGet]
        public IActionResult NewReagent()
        {
            var Suppliers = _context.Suppliers.Select(r => new { r.ID, r.Name }).ToList();
            Reagent reagent = new Reagent();
            

            FormReagentViewModel viewModel = new FormReagentViewModel
            {
                SuppliersChoices = new SelectList(Suppliers, "ID", "Name"),
                Action = "NewReagent"
            };
            _mapper.Map<Reagent>(viewModel);
            return View("FormReagent", viewModel);
        }

        //Read
        [HttpGet]
        public IActionResult GetReagent(int id)
        {
            var Reagent = _context.Reagents.Where(r => r.Id == id)
                .Include(r => r.Supplier)
                .Include(r => r.State)
                .FirstOrDefault();
            if(Reagent == null)
            {
                return NotFound();
            }
            return View(Reagent);
        }

        //Create Reagent
        [HttpPost]
        public IActionResult NewReagent(FormReagentViewModel reagent)
        {
            if(!ModelState.IsValid)
            {
                var Suppliers = _context.Suppliers.Select(r => new { r.ID, r.Name }).ToList();
                FormReagentViewModel viewModel = new FormReagentViewModel
                {
                    SuppliersChoices = new SelectList(Suppliers, "ID", "Name"),
                    Action = "NewReagent"
                };
                _mapper.Map<Reagent>(viewModel);
                return View("FormReagent", viewModel);
            }
            Reagent newReagent = new Reagent();
            _mapper.Map(reagent, newReagent);
            _context.Reagents.Add(newReagent);
            _context.SaveChanges();
            var routeValue = new RouteValueDictionary(new { action = "Index", controller = "Home" });
            return RedirectToRoute(routeValue);
        }

        //Update Reagent get
        public IActionResult UpdateReagent(int id)
        {
            var Reagent = _context.Reagents.Where(r => r.Id == id)
                .Include(r => r.Supplier)
                .Include(r => r.State)
                .FirstOrDefault();
            if (Reagent == null)
            {
                return NotFound();
            }

            var Suppliers = _context.Suppliers.Select(r => new { r.ID, r.Name }).ToList();
            FormReagentViewModel viewModel = new FormReagentViewModel
            {
                SuppliersChoices = new SelectList(Suppliers, "ID", "Name"),
                Action = "UpdateReagent"
            };
            _mapper.Map(Reagent, viewModel);
            return View("FormReagent", viewModel);
        }

        //Update Reagent post
        [HttpPost]
        public IActionResult UpdateReagent(int id, FormReagentViewModel reagent)
        {
            if(!ModelState.IsValid)
            {
                var Suppliers = _context.Suppliers.Select(r => new { r.ID, r.Name }).ToList();
                FormReagentViewModel viewModel = new FormReagentViewModel
                {
                    SuppliersChoices = new SelectList(Suppliers, "ID", "Name"),
                    Action = "UpdateReagent"
                };
                _mapper.Map(reagent, viewModel);
                return View(viewModel);
            }

            var ToEdit = _context.Reagents.FirstOrDefault(r => r.Id == id);
            _mapper.Map(reagent, ToEdit);
            _context.SaveChanges();
            var routeValue = new RouteValueDictionary(new { action = "Index", controller = "Home" });
            return RedirectToRoute(routeValue);
        }

        [HttpPost]
        public IActionResult DeleteReagent(int id)
        {
            var reagent = _context.Reagents.FirstOrDefault(r => r.Id == id);
            if(reagent == null)
            {
                return NotFound();
            }
            _context.Reagents.Remove(reagent);
            _context.SaveChanges();
            var routeValue = new RouteValueDictionary(new { action = "Index", controller = "Home" });
            return RedirectToRoute(routeValue);
        }
    }
}
