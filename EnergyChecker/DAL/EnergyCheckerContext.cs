using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnergyChecker.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EnergyChecker.DAL
{
    public class EnergyCheckerContext : DbContext
    {
        public EnergyCheckerContext() : base("EnergyCheckerContext")
        {
        }

    public DbSet<User> User { get; set; }
    public DbSet<usersAppliances> usersAppliances { get; set; }
    public DbSet<Appliance> Appliance { get; set; }

     protected override void OnModelCreating(DbModelBuilder modelBuilder)
     {
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
     }
    }
}