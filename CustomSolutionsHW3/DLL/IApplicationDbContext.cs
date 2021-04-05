using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IApplicationDbContext
    {
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HiringHistorie> HiringHistories { get; set; }
        public int SaveChanges();
    }
}
