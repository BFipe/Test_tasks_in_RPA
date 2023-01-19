using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecondTaskData.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExcelFiles",
                columns: table => new
                {
                    ExcelFileId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExcelFileName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ExcelFileDescription = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    ExcelFileBankName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TotalActiveOpeningBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    TotalPassiveOpeningBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    TotalDebitNegotiableBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    TotalCreditNegotiableBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    TotalActiveOutgoingBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    TotalPassiveOutgoingBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    ActualTotalActiveOutgoingBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    ActualTotalPassiveOutgoingBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcelFiles", x => x.ExcelFileId);
                });

            migrationBuilder.CreateTable(
                name: "ExcelClasses",
                columns: table => new
                {
                    ExcelClassId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalActiveClassOpeningBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    TotalPassiveClassOpeningBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    TotalDebitClassNegotiableBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    TotalCreditClassNegotiableBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    TotalActiveClassOutgoingBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    TotalPassiveClassOutgoingBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    ActualTotalActiveClassOutgoingBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    ActualTotalPassiveClassOutgoingBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    ExcelFileId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartingValuesRow = table.Column<int>(type: "int", nullable: false),
                    EndingValuesRow = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcelClasses", x => x.ExcelClassId);
                    table.ForeignKey(
                        name: "FK_ExcelClasses_ExcelFiles_ExcelFileId",
                        column: x => x.ExcelFileId,
                        principalTable: "ExcelFiles",
                        principalColumn: "ExcelFileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExcelAccountGroups",
                columns: table => new
                {
                    ExcelAccountGroupId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountingValue = table.Column<int>(type: "int", nullable: false),
                    TotalActiveAccountOpeningBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    TotalPassiveAccountOpeningBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    TotalDebitAccountNegotiableBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    TotalCreditAccountNegotiableBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    TotalActiveAccountOutgoingBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    TotalPassiveAccountOutgoingBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    ActualTotalActiveAccountOutgoingBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    ActualTotalPassiveAccountOutgoingBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    ExcelClassId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartingValuesRow = table.Column<int>(type: "int", nullable: false),
                    EndingValuesRow = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcelAccountGroups", x => x.ExcelAccountGroupId);
                    table.ForeignKey(
                        name: "FK_ExcelAccountGroups_ExcelClasses_ExcelClassId",
                        column: x => x.ExcelClassId,
                        principalTable: "ExcelClasses",
                        principalColumn: "ExcelClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExcelAccounts",
                columns: table => new
                {
                    ExcelAccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountingValue = table.Column<int>(type: "int", nullable: false),
                    ActiveAccountOpeningBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    PassiveAccountOpeningBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    DebitAccountNegotiableBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    CreditAccountNegotiableBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    ActiveAccountOutgoingBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    PassiveAccountOutgoingBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    ActualActiveAccountOutgoingBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    ActualPassiveAccountOutgoingBalance = table.Column<double>(type: "float(24)", precision: 24, scale: 3, nullable: false),
                    ExcelAccountGroupId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcelAccounts", x => x.ExcelAccountId);
                    table.ForeignKey(
                        name: "FK_ExcelAccounts_ExcelAccountGroups_ExcelAccountGroupId",
                        column: x => x.ExcelAccountGroupId,
                        principalTable: "ExcelAccountGroups",
                        principalColumn: "ExcelAccountGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExcelAccountGroups_ExcelClassId",
                table: "ExcelAccountGroups",
                column: "ExcelClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcelAccounts_ExcelAccountGroupId",
                table: "ExcelAccounts",
                column: "ExcelAccountGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcelClasses_ExcelFileId",
                table: "ExcelClasses",
                column: "ExcelFileId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcelFiles_ExcelFileName",
                table: "ExcelFiles",
                column: "ExcelFileName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExcelAccounts");

            migrationBuilder.DropTable(
                name: "ExcelAccountGroups");

            migrationBuilder.DropTable(
                name: "ExcelClasses");

            migrationBuilder.DropTable(
                name: "ExcelFiles");
        }
    }
}
