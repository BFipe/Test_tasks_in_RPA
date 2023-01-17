using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace First_task.Migrations
{
    public partial class Initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TableEntities",
                columns: table => new
                {
                    TableEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: false),
                    LatinSymbols = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CyrillicSymbols = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IntegerNumber = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    DoubleNumber = table.Column<double>(type: "float(2)", precision: 2, scale: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableEntities", x => x.TableEntityId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableEntities");
        }
    }
}
