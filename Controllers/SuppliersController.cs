using AutoMapper;
using HospitalProject.Data;
using HospitalProject.Models;
using HospitalProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProject.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SuppliersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Index get all
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Supplier> AllSuppliers = _context.Suppliers.ToList();
            SupplierIndexViewModel viewModel = new SupplierIndexViewModel
            {
                Suppliers = AllSuppliers
            };
            return View(viewModel);
        }

        //Create Supplier form
        [HttpGet]
        public IActionResult NewSupplier()
        {
            SupplierFormViewModel viewModel = new SupplierFormViewModel
            {
                Action = "NewSupplier"
            };
            return View("FormSupplier", viewModel);
        }

        //Create Supplier Post Route
        [HttpPost]
        public IActionResult NewSupplier(SupplierFormViewModel supplier)
        {
            if(!ModelState.IsValid)
            {
                return View("FormSupplier", supplier);
            }
            var supplierToAdd = new Supplier();
            _mapper.Map(supplier, supplierToAdd);
            _context.Suppliers.Add(supplierToAdd);
            _context.SaveChanges();
            var routeValue = new RouteValueDictionary(new { action = "Index", controller = "Suppliers" });
            return RedirectToRoute(routeValue);
        }

        //Read, Get one record
        [HttpGet]
        public IActionResult GetSupplier(int id)
        {
            var supplier = _context.Suppliers.FirstOrDefault(s => s.ID == id);
            if(supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        //Update Record get
        [HttpGet]
        public IActionResult UpdateSupplier(int id)
        {
            var supplier = _context.Suppliers.FirstOrDefault(s => s.ID == id);
            if(supplier == null)
            {
                return NotFound();
            }
            SupplierFormViewModel viewModel = new SupplierFormViewModel
            {
                Action = "Edit"
            };
            _mapper.Map(supplier, viewModel);
            return View("FormSupplier", viewModel);
        }
    }
}
