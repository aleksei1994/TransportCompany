using Microsoft.EntityFrameworkCore;
using TransportCompany.Models.CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompany.Data
{
    public class TransCompContext : DbContext
    {
        public TransCompContext(DbContextOptions<TransCompContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<CarModel> CarModels { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<TariffPlan> TariffPlans { get; set; }

        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().HasOne(p => p.Operator).WithMany(b => b.TripsOperator).HasForeignKey(p => p.OperatorId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Trip>().HasOne(p => p.Driver).WithMany(b => b.TripsDriver).HasForeignKey(p => p.DriverId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}