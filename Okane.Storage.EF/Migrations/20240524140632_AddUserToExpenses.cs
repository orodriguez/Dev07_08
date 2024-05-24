using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Okane.Storage.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToExpenses : Migration
    {
        private const string UserIdColumn = "UserId";
        private const string ExpensesTable = "Expenses";

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: UserIdColumn,
                table: ExpensesTable,
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_UserId",
                table: ExpensesTable,
                column: UserIdColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: ExpensesTable,
                column: UserIdColumn,
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: ExpensesTable);

            migrationBuilder.DropIndex(
                name: "IX_Expenses_UserId",
                table: ExpensesTable);

            migrationBuilder.DropColumn(
                name: UserIdColumn,
                table: ExpensesTable);
        }
    }
}
