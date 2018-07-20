using FlossMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FlossMVCApp
{
    public class DataContext : DbContext
    {

        public DataContext() : base("DbContext")
        {
        }

        public DbSet<Floss> Flosses { get; set; }
        public DbSet<Company> Companies { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}