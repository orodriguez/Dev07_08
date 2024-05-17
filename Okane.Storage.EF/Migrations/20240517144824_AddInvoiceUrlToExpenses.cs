using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Okane.Storage.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddInvoiceUrlToExpenses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvoiceUrl",
                table: "Expenses",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceUrl",
                table: "Expenses");
        }
    }
}
