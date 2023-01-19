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
            builder.Property(q => q.ActiveAccountOpeningBalance).HasPrecision(24, 3);
            builder.Property(q => q.PassiveAccountOpeningBalance).HasPrecision(24, 3);
            builder.Property(q => q.DebitAccountNegotiableBalance).HasPrecision(24, 3);
            builder.Property(q => q.CreditAccountNegotiableBalance).HasPrecision(24, 3);
            builder.Property(q => q.ActiveAccountOutgoingBalance).HasPrecision(24, 3);
            builder.Property(q => q.PassiveAccountOutgoingBalance).HasPrecision(24, 3);
            builder.Property(q => q.ActualActiveAccountOutgoingBalance).HasPrecision(24, 3);
            builder.Property(q => q.ActualPassiveAccountOutgoingBalance).HasPrecision(24, 3);
        }
    }
}
