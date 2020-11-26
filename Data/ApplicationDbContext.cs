using System;
using System.Collections.Generic;
using System.Text;
using HospitalProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;

namespace HospitalProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Reagent> Reagents { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<OrderReagent> orderReagents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Reagent>().HasData(
                new Reagent
                {
                    Id = 1,
                    Name = "Acetic Acid",
                    Alert = 4,
                    Location = "Cut-Up/Corrosive Cab",
                    stateId = 1,
                    Volume = 2500,
                    MaxVolume = 2500,
                    SupplierID = 1
                },
                new Reagent
                {
                    Id = 2,
                    Name = "Ammonia",
                    Alert = 3,
                    Location = "Cut-Up/Corrosive Cab",
                    stateId = 1,
                    Volume = 2500,
                    MaxVolume = 2500,
                    SupplierID = 2
                },
                new Reagent
                {
                    Id = 3,
                    Name = "Alcian Blue",
                    Alert = 1,
                    Location = "Specials cupboard",
                    stateId = 2,
                    Volume = 25,
                    MaxVolume = 25,
                    SupplierID = 1
                },
                new Reagent
                {
                    Id = 4,
                    Name = "Ammonium iron sulphate",
                    Alert = 2,
                    Location = "Specials Cupboard",
                    stateId = 2,
                    Volume = 500,
                    MaxVolume = 500,
                    SupplierID = 2
                },
                new Reagent
                {
                    Id = 5,
                    Name = "Aniline Blue",
                    Alert = 1,
                    Location = "Specials Cupboard",
                    stateId = 2,
                    Volume = 25,
                    MaxVolume = 25,
                    SupplierID = 3
                },
                new Reagent
                {
                    Id = 6,
                    Name = "Calcium Chloride",
                    Alert = 3,
                    Location = "Specials Cupboard",
                    stateId = 2,
                    Volume = 1000,
                    MaxVolume = 1000,
                    SupplierID = 4
                }
                );

            builder.Entity<Supplier>().HasData(
                new Supplier
                {
                    ID = 1,
                    Name = "Milton Adams",
                    Location = "21C Andromeda Crescent, East Tamaki, Auckland 2013",
                    Contact = "09-271 6415"
                },
                new Supplier
                {
                    ID = 2,
                    Name = "Scharlau",
                    Location = "33 Westpoint Drive, Hobsonville, Auckland 0618",
                    Contact = "0800 342 466"
                },
                new Supplier
                {
                    ID = 3,
                    Name = "Roche",
                    Location = "Sylvia Park",
                    Contact = "0800 652 634"
                },
                new Supplier
                {
                    ID = 4,
                    Name = "Ajax Chemicals",
                    Location = "Minter Ellison Rudd Watts, 88 Shortland Street, Auckland Central, Auckland",
                    Contact = "9429033701356"
                }
                );

            builder.Entity<State>().HasData(
                new State
                {
                    Id = 1,
                    Name = "Liquid"
                },
                new State
                {
                    Id = 2,
                    Name = "Solid"
                }
                );
        }
    }
}
