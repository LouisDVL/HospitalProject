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
        public DbSet<LiquidReagent> LiquidReagents { get; set; }
        public DbSet<SolidReagent> SolidReagents { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<LiquidReagent>()
                .HasOne(l => l.Supplier);

            builder.Entity<SolidReagent>()
                .HasOne(l => l.Supplier);

            builder.Entity<LiquidReagent>().HasData(
                new LiquidReagent
                {
                    ID = 1,
                    Name = "Acetic Acid",
                    AlertCode = 4,
                    LocationInLab = "Cut-Up/Corrosive Cab",
                    currentVolume = 2500,
                    MaxVolume = 2500,
                    SupplierID = 1
                },
                new LiquidReagent
                {
                    ID = 2,
                    Name = "Ammonia",
                    AlertCode = 3,
                    LocationInLab = "Cut-Up/Corrosive Cab",
                    currentVolume = 2500,
                    MaxVolume = 2500,
                    SupplierID = 2
                }
                );

            builder.Entity<SolidReagent>().HasData(
                new SolidReagent
                {
                    ID = 1,
                    Name = "Alcian Blue",
                    AlertCode = 1,
                    LocationInLab = "Specials cupboard",
                    currentVolume = 25,
                    MaxVolume = 25,
                    SupplierID = 1
                },
                new SolidReagent
                {
                    ID = 2,
                    Name = "Ammonium iron sulphate",
                    AlertCode = 2,
                    LocationInLab = "Specials Cupboard",
                    currentVolume = 500,
                    MaxVolume = 500,
                    SupplierID = 2
                },
                new SolidReagent
                {
                    ID = 3,
                    Name = "Aniline Blue",
                    AlertCode = 1,
                    LocationInLab = "Specials Cupboard",
                    currentVolume = 25,
                    MaxVolume = 25,
                    SupplierID = 3
                },
                new SolidReagent
                {
                    ID = 4,
                    Name = "Calcium Chloride",
                    AlertCode = 3,
                    LocationInLab = "Specials Cupboard",
                    currentVolume = 1000,
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
        }
    }
}
