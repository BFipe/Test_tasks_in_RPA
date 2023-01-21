using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecondTaskData.Migrations
{
    /// <inheritdoc />
    public partial class doubletodecimal303 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPassiveOutgoingBalance",
                table: "ExcelFiles",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPassiveOpeningBalance",
                table: "ExcelFiles",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalDebitNegotiableBalance",
                table: "ExcelFiles",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCreditNegotiableBalance",
                table: "ExcelFiles",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalActiveOutgoingBalance",
                table: "ExcelFiles",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalActiveOpeningBalance",
                table: "ExcelFiles",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "ActualTotalPassiveOutgoingBalance",
                table: "ExcelFiles",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "ActualTotalActiveOutgoingBalance",
                table: "ExcelFiles",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPassiveClassOutgoingBalance",
                table: "ExcelClasses",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPassiveClassOpeningBalance",
                table: "ExcelClasses",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalDebitClassNegotiableBalance",
                table: "ExcelClasses",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCreditClassNegotiableBalance",
                table: "ExcelClasses",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalActiveClassOutgoingBalance",
                table: "ExcelClasses",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalActiveClassOpeningBalance",
                table: "ExcelClasses",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "ActualTotalPassiveClassOutgoingBalance",
                table: "ExcelClasses",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "ActualTotalActiveClassOutgoingBalance",
                table: "ExcelClasses",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "PassiveAccountOutgoingBalance",
                table: "ExcelAccounts",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "PassiveAccountOpeningBalance",
                table: "ExcelAccounts",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "DebitAccountNegotiableBalance",
                table: "ExcelAccounts",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "CreditAccountNegotiableBalance",
                table: "ExcelAccounts",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "ActualPassiveAccountOutgoingBalance",
                table: "ExcelAccounts",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "ActualActiveAccountOutgoingBalance",
                table: "ExcelAccounts",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "ActiveAccountOutgoingBalance",
                table: "ExcelAccounts",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "ActiveAccountOpeningBalance",
                table: "ExcelAccounts",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPassiveAccountOutgoingBalance",
                table: "ExcelAccountGroups",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPassiveAccountOpeningBalance",
                table: "ExcelAccountGroups",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalDebitAccountNegotiableBalance",
                table: "ExcelAccountGroups",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCreditAccountNegotiableBalance",
                table: "ExcelAccountGroups",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalActiveAccountOutgoingBalance",
                table: "ExcelAccountGroups",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalActiveAccountOpeningBalance",
                table: "ExcelAccountGroups",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "ActualTotalPassiveAccountOutgoingBalance",
                table: "ExcelAccountGroups",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "ActualTotalActiveAccountOutgoingBalance",
                table: "ExcelAccountGroups",
                type: "decimal(30,3)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(24)",
                oldPrecision: 24,
                oldScale: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TotalPassiveOutgoingBalance",
                table: "ExcelFiles",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPassiveOpeningBalance",
                table: "ExcelFiles",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalDebitNegotiableBalance",
                table: "ExcelFiles",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalCreditNegotiableBalance",
                table: "ExcelFiles",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalActiveOutgoingBalance",
                table: "ExcelFiles",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalActiveOpeningBalance",
                table: "ExcelFiles",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "ActualTotalPassiveOutgoingBalance",
                table: "ExcelFiles",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "ActualTotalActiveOutgoingBalance",
                table: "ExcelFiles",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPassiveClassOutgoingBalance",
                table: "ExcelClasses",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPassiveClassOpeningBalance",
                table: "ExcelClasses",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalDebitClassNegotiableBalance",
                table: "ExcelClasses",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalCreditClassNegotiableBalance",
                table: "ExcelClasses",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalActiveClassOutgoingBalance",
                table: "ExcelClasses",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalActiveClassOpeningBalance",
                table: "ExcelClasses",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "ActualTotalPassiveClassOutgoingBalance",
                table: "ExcelClasses",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "ActualTotalActiveClassOutgoingBalance",
                table: "ExcelClasses",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "PassiveAccountOutgoingBalance",
                table: "ExcelAccounts",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "PassiveAccountOpeningBalance",
                table: "ExcelAccounts",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "DebitAccountNegotiableBalance",
                table: "ExcelAccounts",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "CreditAccountNegotiableBalance",
                table: "ExcelAccounts",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "ActualPassiveAccountOutgoingBalance",
                table: "ExcelAccounts",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "ActualActiveAccountOutgoingBalance",
                table: "ExcelAccounts",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "ActiveAccountOutgoingBalance",
                table: "ExcelAccounts",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "ActiveAccountOpeningBalance",
                table: "ExcelAccounts",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPassiveAccountOutgoingBalance",
                table: "ExcelAccountGroups",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPassiveAccountOpeningBalance",
                table: "ExcelAccountGroups",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalDebitAccountNegotiableBalance",
                table: "ExcelAccountGroups",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalCreditAccountNegotiableBalance",
                table: "ExcelAccountGroups",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalActiveAccountOutgoingBalance",
                table: "ExcelAccountGroups",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalActiveAccountOpeningBalance",
                table: "ExcelAccountGroups",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "ActualTotalPassiveAccountOutgoingBalance",
                table: "ExcelAccountGroups",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");

            migrationBuilder.AlterColumn<double>(
                name: "ActualTotalActiveAccountOutgoingBalance",
                table: "ExcelAccountGroups",
                type: "float(24)",
                precision: 24,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,3)");
        }
    }
}
