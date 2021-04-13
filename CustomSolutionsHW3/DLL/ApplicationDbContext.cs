using Bogus;
using DAL.Entities;
using FizzWare.NBuilder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HiringHistorie> HiringHistories { get; set; }

    }
}
