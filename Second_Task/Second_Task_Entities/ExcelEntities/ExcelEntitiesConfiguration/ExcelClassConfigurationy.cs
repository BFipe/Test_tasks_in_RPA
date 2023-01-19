using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Task_Entities.ExcelEntities.ExcelEntitiesConfiguration
{
    public class ExcelClassConfiguration : IEntityTypeConfiguration<ExcelClass>
    {
        public void Configure(EntityTypeBuilder<ExcelClass> builder)
        {
            //IK
            builder.HasKey(q => q.ExcelClassId);

            //Main properties
            builder.Property(q => q.TotalActiveClassOpeningBalance).HasPrecision(24, 3);
            builder.Property(q => q.TotalPassiveClassOpeningBalance).HasPrecision(24, 3);
            builder.Property(q => q.TotalDebitClassNegotiableBalance).HasPrecision(24, 3);
            builder.Property(q => q.TotalCreditClassNegotiableBalance).HasPrecision(24, 3);
            builder.Property(q => q.TotalActiveClassOutgoingBalance).HasPrecision(24, 3);
            builder.Property(q => q.TotalPassiveClassOutgoingBalance).HasPrecision(24, 3);
            builder.Property(q => q.ActualTotalActiveClassOutgoingBalance).HasPrecision(24, 3);
            builder.Property(q => q.ActualTotalPassiveClassOutgoingBalance).HasPrecision(24, 3);

            //Many-to-one FK
            builder.HasMany(q => q.ExcelAccountGroups).WithOne(q => q.ExcelClass).HasForeignKey(q => q.ExcelClassId);
        }
    }
}
