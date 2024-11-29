using FormulaOneInfo.Data.Concrete.EntityFramework.Mappings;
using FormulaOneInfo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Data.Concrete.EntityFramework.Contexts
{
    public class FormulaOneContext:DbContext
    {
        public DbSet<GrandPrix> GrandPrixes { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-O0TKT7U;Database=FormulaOne;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True; TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GrandPrixMap());
            modelBuilder.ApplyConfiguration(new PilotMap());
            modelBuilder.ApplyConfiguration(new ResultMap());
            modelBuilder.ApplyConfiguration(new SeasonMap());
            modelBuilder.ApplyConfiguration(new TeamMap());
        }
    }
}
