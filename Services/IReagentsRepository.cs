using HospitalProject.Models;
using System.Collections.Generic;

namespace HospitalProject.Services
{
    public interface IReagentsRepository
    {
        Reagent GetReagent(int id);
        IEnumerable<Reagent> GetReagents();
        void RemoveReagent(int id);
        bool Save();
    }
}