using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ApplicationDbContex : DbContext, IApplicationDbContex
    {
        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options) : base(options)
        {

        }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HiringHistorie> HiringHistories { get; set; }
    }
}
