using AutoMapper;
using HospitalProject.Data;
using HospitalProject.Models;
using HospitalProject.Services;
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
        private readonly IReagentsRepository _reagentsRepository;

        public SuppliersController(ApplicationDbContext context, IMapper mapper, IReagentsRepository reagentsRepository)
        {
            _context = context;
            _mapper = mapper;
            _reagentsRepository = reagentsRepository;
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
        [ValidateAntiForgeryToken]
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
            var reagents = _context.Reagents.Where(r => r.SupplierID == id).ToList();
            SupplierGetViewModel viewModel = new SupplierGetViewModel
            {
                Supplier = supplier,
                Reagents = reagents
            };
            return View(viewModel);
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
                Action = "UpdateSupplier"
            };
            _mapper.Map(supplier, viewModel);
            return View("FormSupplier", viewModel);
        }

        //Update Record Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSupplier(int id, SupplierFormViewModel supplier)
        {
            if(!ModelState.IsValid)
            {
                return View("FormSupplier", supplier);
            }

            var supplierToEdit = _context.Suppliers.FirstOrDefault(s => s.ID == id);
            _mapper.Map(supplier, supplierToEdit);
            _context.SaveChanges();
            var routeValue = new RouteValueDictionary(new { action = "Index", controller = "Suppliers" });
            return RedirectToRoute(routeValue);
        }

        //Delete route for suppliers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSupplier(int id, IEnumerable<Reagent> reagents = null)
        {
            var supplier = _context.Suppliers.FirstOrDefault(s => s.ID == id);
            if(supplier == null)
            {
                return NotFound();
            }
            if(reagents != null)
            {
                foreach(Reagent agent in reagents)
                {
                    _reagentsRepository.RemoveReagent(agent.Id);
                }
                
            };
            _context.Remove(supplier);
            _context.SaveChanges();
            var routeValue = new RouteValueDictionary(new { action = "Index", controller = "Suppliers" });
            return RedirectToRoute(routeValue);
        }
    }
}
