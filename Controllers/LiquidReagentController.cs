using HospitalProject.Data;
using HospitalProject.Models;
using HospitalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.Controllers
{
    public class LiquidReagentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LiquidReagentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var liquidReagents = _context.LiquidReagents.Include(l => l.Supplier).ToList();
            return View(liquidReagents);
        }

        [HttpGet]
        public IActionResult New()
        {
            var ViewModel = new LiquidReagentCreateViewModel
            {
                LiquidReagent = new LiquidReagent()
            };
            return View(ViewModel);
        }
    }
}
