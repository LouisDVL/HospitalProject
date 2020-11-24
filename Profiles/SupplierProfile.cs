using AutoMapper;
using HospitalProject.Models;
using HospitalProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace HospitalProject.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierFormViewModel>().ReverseMap();
        }
    }
}
