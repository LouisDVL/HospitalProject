using HospitalProject.Data;
using Microsoft.AspNetCore.Mvc;
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

        public ReagentController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Create
        [HttpGet]
        public IActionResult NewReagent()
        {
            return View();
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

        
    }
}
