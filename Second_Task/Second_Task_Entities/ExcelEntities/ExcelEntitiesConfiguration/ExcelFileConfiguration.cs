using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Task_Entities.ExcelEntities.ExcelEntitiesConfiguration
{
    public class ExcelFileConfiguration : IEntityTypeConfiguration<ExcelFile>
    {
        public void Configure(EntityTypeBuilder<ExcelFile> builder)
        {
            //IK
            builder.HasKey(q => q.ExcelFileId);

            //Each file must have unique name
            builder.HasIndex(q => q.ExcelFileName).IsUnique();

            //File data
            builder.Property(q => q.ExcelFileName).HasMaxLength(30);
            builder.Property(q => q.ExcelFileDescription).HasMaxLength(180);
            builder.Property(q => q.ExcelFileBankName).HasMaxLength(30);

            //Main properties
            builder.Property(q => q.TotalActiveOpeningBalance).HasPrecision(24, 3);
            builder.Property(q => q.TotalPassiveOpeningBalance).HasPrecision(24, 3);
            builder.Property(q => q.TotalDebitNegotiableBalance).HasPrecision(24, 3);
            builder.Property(q => q.TotalCreditNegotiableBalance).HasPrecision(24, 3);
            builder.Property(q => q.TotalActiveOutgoingBalance).HasPrecision(24, 3);
            builder.Property(q => q.TotalPassiveOutgoingBalance).HasPrecision(24, 3);
            builder.Property(q => q.ActualTotalActiveOutgoingBalance).HasPrecision(24, 3);
            builder.Property(q => q.ActualTotalPassiveOutgoingBalance).HasPrecision(24, 3);

            //Many-to-one FK
            builder.HasMany(q => q.ExcelClasses).WithOne(q => q.ExcelFile).HasForeignKey(q => q.ExcelFileId);   
        }
    }
}
