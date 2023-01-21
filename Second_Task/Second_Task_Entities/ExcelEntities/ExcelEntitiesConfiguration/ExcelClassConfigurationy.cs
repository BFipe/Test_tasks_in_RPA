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
            builder.Property(q => q.TotalActiveClassOpeningBalance).HasColumnType("decimal(30,2)");
            builder.Property(q => q.TotalPassiveClassOpeningBalance).HasColumnType("decimal(30,2)");
            builder.Property(q => q.TotalDebitClassNegotiableBalance).HasColumnType("decimal(30,2)");
            builder.Property(q => q.TotalCreditClassNegotiableBalance).HasColumnType("decimal(30,2)");
            builder.Property(q => q.TotalActiveClassOutgoingBalance).HasColumnType("decimal(30,2)");
            builder.Property(q => q.TotalPassiveClassOutgoingBalance).HasColumnType("decimal(30,2)");
            builder.Property(q => q.ActualTotalActiveClassOutgoingBalance).HasColumnType("decimal(30,2)");
            builder.Property(q => q.ActualTotalPassiveClassOutgoingBalance).HasColumnType("decimal(30,2)");

            //Many-to-one FK
            builder.HasMany(q => q.ExcelAccountGroups).WithOne(q => q.ExcelClass).HasForeignKey(q => q.ExcelClassId);
        }
    }
}
