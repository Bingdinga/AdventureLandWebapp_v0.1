﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdventureLandWebapp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection.Metadata;
using AdventureLandWebapp.Controllers;

namespace AdventureLandWebapp.Data
{
    public class AdventureLandWebappContext : IdentityDbContext
    {
        public AdventureLandWebappContext (DbContextOptions<AdventureLandWebappContext> options)
            : base(options)
        {
        }

        public DbSet<AdventureLandWebapp.Models.EMPLOYEE> EMPLOYEE { get; set; } = default!;
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<AdventureLandWebapp.Models.SHOP> SHOP { get; set; } = default!;

        public DbSet<AdventureLandWebapp.Models.ATTRACTION> ATTRACTION { get; set; } = default!;

        public DbSet<AdventureLandWebapp.Models.EVENT> EVENT { get; set; } = default!;

        public DbSet<AdventureLandWebapp.Models.SHOP_INVENTORY_ITEM> SHOP_INVENTORY_ITEM { get; set; } = default!;

        public DbSet<AdventureLandWebapp.Models.SHOP_EMPLOYEE> SHOP_EMPLOYEE { get; set; } = default!;

        public DbSet<AdventureLandWebapp.Models.EVENT_WORK_REC> EVENT_WORK_REC { get; set; } = default!;

        public DbSet<AdventureLandWebapp.Models.MAINTENENCE_REC> MAINTENENCE_REC { get; set; } = default!;

        public DbSet<AdventureLandWebapp.Models.MAINTENENCE_PERSONNEL_REC> MAINTENENCE_PERSONNEL_REC { get; set; } = default!;

        public DbSet<AdventureLandWebapp.Models.ATTRACTION_EMPLOYEE> ATTRACTION_EMPLOYEE { get; set; } = default!;

        public DbSet<AdventureLandWebapp.Models.PERSONNEL_WORK_REC> PERSONNEL_WORK_REC { get; set; } = default!;

        public DbSet<AdventureLandWebapp.Models.TICKET> TICKET { get; set; } = default!;

        public DbSet<AdventureLandWebapp.Models.TICKET_TYPES> TICKET_TYPES { get; set; } = default!;

        public DbSet<AdventureLandWebapp.Models.GUEST> GUEST { get; set; } = default!;

        public DbSet<AdventureLandWebapp.Models.GUEST_REC> GUEST_REC { get; set; } = default!;

        public DbSet<AdventureLandWebapp.Models.SHOP_ITEM> SHOP_ITEM { get; set; } = default!;

        // letting  EF Core know that the target table has a trigger
        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<MAINTENENCE_REC>()
                 .ToTable(tb => tb.HasTrigger("SomeTrigger"));
         }*/
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Add(_ => new BlankTriggerAddingConvention());
        }
    }
}
