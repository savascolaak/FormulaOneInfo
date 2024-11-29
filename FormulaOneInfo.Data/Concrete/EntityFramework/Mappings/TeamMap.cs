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
    public class TeamMap : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x=>x.Name).HasMaxLength(255);
            builder.Property(x=>x.StartedDate).IsRequired();
            builder.Property(x=>x.Thumbnail).HasMaxLength(500);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Note).IsRequired(false);
            builder.Property(x => x.Note).HasMaxLength(500);
            builder.ToTable("Teams");
            builder.HasData(new Team
            {
                Id = 1,
                Name = "Mercedes-Amg Petronas",
                StartedDate = new DateTime(2010,01,01),
                Thumbnail = "default.jpg",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Note = "Formula 1 Mercedes Team"
            });
        }
    }
}
