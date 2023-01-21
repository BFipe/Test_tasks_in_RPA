using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Task_Entities.ExcelEntities.ExcelEntitiesConfiguration
{
    public class ExcelAccountConfiguration : IEntityTypeConfiguration<ExcelAccount>
    {
        public void Configure(EntityTypeBuilder<ExcelAccount> builder)
        {
            //IK
            builder.HasKey(q => q.ExcelAccountId);

            //Main properties
            builder.Property(q => q.ActiveAccountOpeningBalance).HasColumnType("decimal(30,2)");
            builder.Property(q => q.PassiveAccountOpeningBalance).HasColumnType("decimal(30,2)");
            builder.Property(q => q.DebitAccountNegotiableBalance).HasColumnType("decimal(30,2)");
            builder.Property(q => q.CreditAccountNegotiableBalance).HasColumnType("decimal(30,2)");
            builder.Property(q => q.ActiveAccountOutgoingBalance).HasColumnType("decimal(30,2)");
            builder.Property(q => q.PassiveAccountOutgoingBalance).HasColumnType("decimal(30,2)");
            builder.Property(q => q.ActualActiveAccountOutgoingBalance).HasColumnType("decimal(30,2)");
            builder.Property(q => q.ActualPassiveAccountOutgoingBalance).HasColumnType("decimal(30,2)");
        }
    }
}
