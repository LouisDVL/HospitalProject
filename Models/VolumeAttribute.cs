using HospitalProject.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProject.Models
{
    public class VolumeAttribute : ValidationAttribute
    {
        public VolumeAttribute()
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var reagent = (FormReagentViewModel)validationContext.ObjectInstance;
            if(reagent.Volume > reagent.MaxVolume)
            {
                return new ValidationResult($"Volume cannot be higher than {reagent.MaxVolume}.");
            }
            return ValidationResult.Success;
        }
    }
}
