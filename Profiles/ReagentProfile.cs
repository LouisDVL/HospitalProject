using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalProject.Models;
using HospitalProject.ViewModel;

namespace HospitalProject.Profiles
{
    public class ReagentProfile : Profile
    {
        public ReagentProfile()
        {
            CreateMap<Reagent, FormReagentViewModel>().ReverseMap();
            CreateMap<FormReagentViewModel, FormReagentViewModel>();
        }
    }
}
