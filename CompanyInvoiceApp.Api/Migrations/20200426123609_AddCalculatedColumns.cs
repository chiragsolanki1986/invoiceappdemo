using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyInvoiceApp.Api.Migrations
{
    public partial class AddCalculatedColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BalanceDue",
                table: "Invoices",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SubTotal",
                table: "Invoices",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SubTotalLessDiscount",
                table: "Invoices",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalTax",
                table: "Invoices",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalanceDue",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "SubTotalLessDiscount",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "TotalTax",
                table: "Invoices");
        }
    }
}
