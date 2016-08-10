using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testASP.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace testASP.DAL
{
    public class FilmsContext : DbContext
    {
        public FilmsContext() : base("FilmsContext")
        {
        }

        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}