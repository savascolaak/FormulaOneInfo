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
    public class SeasonMap : IEntityTypeConfiguration<Season>
    {
        public void Configure(EntityTypeBuilder<Season> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x=>x.Name).HasMaxLength(50);
            builder.Property(x=>x.StartedDate).IsRequired();
            builder.Property(x=>x.EndDate).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Note).IsRequired(false);
            builder.Property(x => x.Note).HasMaxLength(500);
            builder.ToTable("Seasons");
            builder.HasData(new Season
            {
                Id = 1,
                Name = "Formula 1 2024 Sezonu",
                StartedDate = new DateTime(2024,03,1),
                EndDate = new DateTime(2024, 12, 8),
                CreatedDate = DateTime.Now,
                ModifiedDate =DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Note = "Formula 1 2024 Sezonu"
            });
        }
    }
}
