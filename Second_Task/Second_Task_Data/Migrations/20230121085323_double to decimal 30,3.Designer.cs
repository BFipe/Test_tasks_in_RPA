// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Second_Task_Data;

#nullable disable

namespace SecondTaskData.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230121085323_double to decimal 30,3")]
    partial class doubletodecimal303
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Second_Task_Entities.ExcelEntities.ExcelAccount", b =>
                {
                    b.Property<string>("ExcelAccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccountingValue")
                        .HasColumnType("int");

                    b.Property<decimal>("ActiveAccountOpeningBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("ActiveAccountOutgoingBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("ActualActiveAccountOutgoingBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("ActualPassiveAccountOutgoingBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("CreditAccountNegotiableBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("DebitAccountNegotiableBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<string>("ExcelAccountGroupId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("PassiveAccountOpeningBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("PassiveAccountOutgoingBalance")
                        .HasColumnType("decimal(30,3)");

                    b.HasKey("ExcelAccountId");

                    b.HasIndex("ExcelAccountGroupId");

                    b.ToTable("ExcelAccounts");
                });

            modelBuilder.Entity("Second_Task_Entities.ExcelEntities.ExcelAccountGroup", b =>
                {
                    b.Property<string>("ExcelAccountGroupId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccountingValue")
                        .HasColumnType("int");

                    b.Property<decimal>("ActualTotalActiveAccountOutgoingBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("ActualTotalPassiveAccountOutgoingBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<int>("EndingValuesRow")
                        .HasColumnType("int");

                    b.Property<string>("ExcelClassId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StartingValuesRow")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalActiveAccountOpeningBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("TotalActiveAccountOutgoingBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("TotalCreditAccountNegotiableBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("TotalDebitAccountNegotiableBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("TotalPassiveAccountOpeningBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("TotalPassiveAccountOutgoingBalance")
                        .HasColumnType("decimal(30,3)");

                    b.HasKey("ExcelAccountGroupId");

                    b.HasIndex("ExcelClassId");

                    b.ToTable("ExcelAccountGroups");
                });

            modelBuilder.Entity("Second_Task_Entities.ExcelEntities.ExcelClass", b =>
                {
                    b.Property<string>("ExcelClassId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("ActualTotalActiveClassOutgoingBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("ActualTotalPassiveClassOutgoingBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<int>("EndingValuesRow")
                        .HasColumnType("int");

                    b.Property<string>("ExcelFileId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StartingValuesRow")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalActiveClassOpeningBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("TotalActiveClassOutgoingBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("TotalCreditClassNegotiableBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("TotalDebitClassNegotiableBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("TotalPassiveClassOpeningBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("TotalPassiveClassOutgoingBalance")
                        .HasColumnType("decimal(30,3)");

                    b.HasKey("ExcelClassId");

                    b.HasIndex("ExcelFileId");

                    b.ToTable("ExcelClasses");
                });

            modelBuilder.Entity("Second_Task_Entities.ExcelEntities.ExcelFile", b =>
                {
                    b.Property<string>("ExcelFileId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("ActualTotalActiveOutgoingBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("ActualTotalPassiveOutgoingBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<string>("ExcelFileBankName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ExcelFileDescription")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)");

                    b.Property<string>("ExcelFileName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("TotalActiveOpeningBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("TotalActiveOutgoingBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("TotalCreditNegotiableBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("TotalDebitNegotiableBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("TotalPassiveOpeningBalance")
                        .HasColumnType("decimal(30,3)");

                    b.Property<decimal>("TotalPassiveOutgoingBalance")
                        .HasColumnType("decimal(30,3)");

                    b.HasKey("ExcelFileId");

                    b.HasIndex("ExcelFileName")
                        .IsUnique();

                    b.ToTable("ExcelFiles");
                });

            modelBuilder.Entity("Second_Task_Entities.ExcelEntities.ExcelAccount", b =>
                {
                    b.HasOne("Second_Task_Entities.ExcelEntities.ExcelAccountGroup", "ExcelAccountGroup")
                        .WithMany("ExcelAccounts")
                        .HasForeignKey("ExcelAccountGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExcelAccountGroup");
                });

            modelBuilder.Entity("Second_Task_Entities.ExcelEntities.ExcelAccountGroup", b =>
                {
                    b.HasOne("Second_Task_Entities.ExcelEntities.ExcelClass", "ExcelClass")
                        .WithMany("ExcelAccountGroups")
                        .HasForeignKey("ExcelClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExcelClass");
                });

            modelBuilder.Entity("Second_Task_Entities.ExcelEntities.ExcelClass", b =>
                {
                    b.HasOne("Second_Task_Entities.ExcelEntities.ExcelFile", "ExcelFile")
                        .WithMany("ExcelClasses")
                        .HasForeignKey("ExcelFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExcelFile");
                });

            modelBuilder.Entity("Second_Task_Entities.ExcelEntities.ExcelAccountGroup", b =>
                {
                    b.Navigation("ExcelAccounts");
                });

            modelBuilder.Entity("Second_Task_Entities.ExcelEntities.ExcelClass", b =>
                {
                    b.Navigation("ExcelAccountGroups");
                });

            modelBuilder.Entity("Second_Task_Entities.ExcelEntities.ExcelFile", b =>
                {
                    b.Navigation("ExcelClasses");
                });
#pragma warning restore 612, 618
        }
    }
}
