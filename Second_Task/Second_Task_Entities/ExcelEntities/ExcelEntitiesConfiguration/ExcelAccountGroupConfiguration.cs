using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Task_Entities.ExcelEntities.ExcelEntitiesConfiguration
{
    public class ExcelAccountGroupConfiguration : IEntityTypeConfiguration<ExcelAccountGroup>
    {
        public void Configure(EntityTypeBuilder<ExcelAccountGroup> builder)
        {
            //IK
            builder.HasKey(q => q.ExcelAccountGroupId);

            //Main properties
            builder.Property(q => q.TotalActiveAccountOpeningBalance).HasPrecision(24, 3);
            builder.Property(q => q.TotalPassiveAccountOpeningBalance).HasPrecision(24, 3);
            builder.Property(q => q.TotalDebitAccountNegotiableBalance).HasPrecision(24, 3);
            builder.Property(q => q.TotalCreditAccountNegotiableBalance).HasPrecision(24, 3);
            builder.Property(q => q.TotalActiveAccountOutgoingBalance).HasPrecision(24, 3);
            builder.Property(q => q.TotalPassiveAccountOutgoingBalance).HasPrecision(24, 3);
            builder.Property(q => q.ActualTotalActiveAccountOutgoingBalance).HasPrecision(24, 3);
            builder.Property(q => q.ActualTotalPassiveAccountOutgoingBalance).HasPrecision(24, 3);

            //Many-to-one FK
            builder.HasMany(q => q.ExcelAccounts).WithOne(q => q.ExcelAccountGroup).HasForeignKey(q => q.ExcelAccountGroupId);
        }
    }
}
