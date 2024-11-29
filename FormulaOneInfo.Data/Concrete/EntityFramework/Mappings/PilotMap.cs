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
    public class PilotMap : IEntityTypeConfiguration<Pilot>
    {
        public void Configure(EntityTypeBuilder<Pilot> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.FirstName).HasMaxLength(100);
            builder.Property(x=>x.FirstName).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(100);
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x=>x.DateOfBirth).IsRequired();
            builder.Property(x=>x.Thumbnail).HasMaxLength(500);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Note).IsRequired(false);
            builder.Property(x => x.Note).HasMaxLength(500);
            builder.ToTable("Pilots");
            builder.HasData(new Pilot
            {
                Id = 1,
                FirstName = "Lewis",
                LastName = "Hamilton",
                DateOfBirth = new DateTime(1985,1,7),
                Thumbnail = "Default.jpg",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Note = "Lewis Hamilton İngiliz Pilot"

            });
        }
    }
}
