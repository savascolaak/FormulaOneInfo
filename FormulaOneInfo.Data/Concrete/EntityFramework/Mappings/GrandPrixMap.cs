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
    public class GrandPrixMap : IEntityTypeConfiguration<GrandPrix>
    {
        public void Configure(EntityTypeBuilder<GrandPrix> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Track).IsRequired();
            builder.Property(x => x.Track).HasMaxLength(150);
            builder.Property(x => x.Country).IsRequired();
            builder.Property(x => x.Country).HasMaxLength(150);
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.City).HasMaxLength(150);
            builder.Property(x => x.GrandPrixDate).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Note).IsRequired(false);
            builder.Property(x => x.Note).HasMaxLength(500);
            builder.HasOne<Season>(x=>x.Season).WithMany(y=>y.GrandPrixes).HasForeignKey(y=>y.SeasonId);
            builder.ToTable("GrandPrixes");
            builder.HasData(new GrandPrix
            {
                Id = 1,
                Name = "Formula 2024 Bahreyn GP",
                Track = "Sakhir",
                Country = "Birleşik Arap Emirlikleri",
                City = "Bahreyn",
                GrandPrixDate = new DateTime(2024, 3, 2),
                SeasonId = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
                IsActive = true, 
                Note = "Formula 1 2024 Bahreyn GP"

            });
        }
    }
}
