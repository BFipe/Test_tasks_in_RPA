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
            builder.Property(q => q.TotalActiveAccountOpeningBalance).HasColumnType("decimal(30,2)");
            builder.Property(q => q.TotalPassiveAccountOpeningBalance).HasColumnType("decimal(30,2)");
            builder.Property(q => q.TotalDebitAccountNegotiableBalance).HasColumnType("decimal(30,2)");
            builder.Property(q => q.TotalCreditAccountNegotiableBalance).HasColumnType("decimal(30,2)");
            builder.Property(q => q.TotalActiveAccountOutgoingBalance).HasColumnType("decimal(30,2)");
            builder.Property(q => q.TotalPassiveAccountOutgoingBalance).HasColumnType("decimal(30,2)");
            builder.Property(q => q.ActualTotalActiveAccountOutgoingBalance).HasColumnType("decimal(30,2)");
            builder.Property(q => q.ActualTotalPassiveAccountOutgoingBalance).HasColumnType("decimal(30,2)");

            //Many-to-one FK
            builder.HasMany(q => q.ExcelAccounts).WithOne(q => q.ExcelAccountGroup).HasForeignKey(q => q.ExcelAccountGroupId);
        }
    }
}
