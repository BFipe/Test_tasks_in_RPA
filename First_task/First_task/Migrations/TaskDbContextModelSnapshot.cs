﻿// <auto-generated />
using System;
using First_task.DatabaseOperations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace First_task.Migrations
{
    [DbContext(typeof(TaskDbContext))]
    partial class TaskDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("First_task.DatabaseOperations.Entities.TableEntity", b =>
                {
                    b.Property<int>("TableEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TableEntityId"), 1L, 1);

                    b.Property<string>("CyrillicSymbols")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("Date")
                        .HasMaxLength(10)
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DecimalNumber")
                        .HasColumnType("decimal(14,8)");

                    b.Property<int>("IntegerNumber")
                        .HasMaxLength(9)
                        .HasColumnType("int");

                    b.Property<string>("LatinSymbols")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("TableEntityId");

                    b.ToTable("TableEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
