﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HospitalProject.Models;
using HospitalProject.Data;
using Microsoft.EntityFrameworkCore;
using HospitalProject.ViewModels;

namespace HospitalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var liquidReagent = _context.LiquidReagents.Include(l => l.Supplier).ToList();
            var solidReagent = _context.SolidReagents.Include(l => l.Supplier).ToList();
            var ViewModel = new HomeIndexViewModel
            {
                LiquidReagents = liquidReagent,
                SolidReagents = solidReagent
            };
            return View(ViewModel);
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