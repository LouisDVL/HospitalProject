using HospitalProject.Data;
using HospitalProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProject.Services
{
    public class ReagentsRepository : IReagentsRepository
    {
        private readonly ApplicationDbContext _context;

        public ReagentsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Reagent> GetReagents()
        {
            return _context.Reagents.Include(r => r.Supplier).Include(r => r.State).ToList();
        }

        public Reagent GetReagent(int id)
        {
            return _context.Reagents.Where(r => r.Id == id)
                .Include(r => r.Supplier)
                .Include(r => r.State)
                .FirstOrDefault();
        }

        public void RemoveReagent(int id)
        {
            var reagent = _context.Reagents.FirstOrDefault(r => r.Id == id);
            _context.Reagents.Remove(reagent);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
