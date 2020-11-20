﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProject.Models
{
    public class State
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}