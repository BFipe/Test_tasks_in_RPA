using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_task.DatabaseOperations.Entities
{
    public class TableEntityConfiguration : IEntityTypeConfiguration<TableEntity>
    {
        public void Configure(EntityTypeBuilder<TableEntity> builder)
        {
            builder.HasKey(q => q.TableEntityId);
            builder.Property(q => q.TableEntityId).ValueGeneratedOnAdd();

            //Coniguring table's properties 

            builder.Property(q => q.Date).HasMaxLength(10).IsRequired();
            builder.Property(q => q.CyrillicSymbols).HasMaxLength(10).IsRequired();
            builder.Property(q => q.LatinSymbols).HasMaxLength(10).IsRequired();

            builder.Property(q => q.DoubleNumber).HasPrecision(2, 8).IsRequired();
            builder.Property(q => q.IntegerNumber).HasMaxLength(9).IsRequired();
        }
    }
}
