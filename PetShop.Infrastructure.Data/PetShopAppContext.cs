﻿using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class PetShopAppContext : DbContext
    {
        public PetShopAppContext(DbContextOptions<PetShopAppContext> opt) : base(opt)
        {}

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>()
                .HasMany(owner => owner.Pets)
                .WithOne(pet => pet.Owner)
                .OnDelete(DeleteBehavior.SetNull);
            /*
            modelBuilder.Entity<Owner>()
            .HasMany(owner => owner.Pets)
            .WithOne(pet => pet.Owner);
            */
            
        }
    }
}
