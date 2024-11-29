using FormulaOneInfo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneInfo.Data.Concrete.EntityFramework.Mappings
{
    public class ResultMap : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.Order).IsRequired();
            builder.Property(x => x.Points).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Note).IsRequired(false);
            builder.Property(x => x.Note).HasMaxLength(500);
            //builder.HasOne<Season>(x => x.Season).WithMany(y => y.Results).HasForeignKey(z => z.SeasonId).OnDelete(DeleteBehavior.Restrict);
            //builder.HasOne<Season>(x => x.Season).WithMany(y => y.Results).OnDelete(DeleteBehavior.Restrict).IsRequired(false).HasForeignKey(z=>z.SeasonId);
            builder.HasOne<GrandPrix>(x => x.GrandPrix).WithMany(y => y.Results).HasForeignKey(z => z.GrandPrixId);
            builder.HasOne<Pilot>(x => x.Pilot).WithMany(y => y.Results).HasForeignKey(z => z.PilotId);
            builder.HasOne<Team>(x => x.Team).WithMany(y => y.Results).HasForeignKey(z => z.TeamId);
            builder.ToTable("Results");
            builder.HasData(new Result
            {
                Id=1,
                Order=7,
                Points = 6,                
                GrandPrixId=1,
                PilotId=1,
                TeamId=1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Note = "Results"
            });

        }
    }
}
