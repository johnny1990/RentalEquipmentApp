﻿using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Equipments> Equipments { get; set; }
        public DbSet<Societies> Societies { get; set; }
        public DbSet<Rentals> Rentals { get; set; }
        public DbSet<RentalsData> RentalsData { get; set; }

    }
}