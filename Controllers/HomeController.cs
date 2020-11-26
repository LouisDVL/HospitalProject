using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HospitalProject.Models;
using HospitalProject.Data;
using Microsoft.EntityFrameworkCore;
using HospitalProject.Services;

namespace HospitalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IReagentsRepository _reagentsRepository;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IReagentsRepository reagentsRepository)
        {
            _logger = logger;
            _context = context;
            _reagentsRepository = reagentsRepository;

        }

        public IActionResult Index()
        {
            IEnumerable<Reagent> reagents = _reagentsRepository.GetReagents();
            
            return View(reagents);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
