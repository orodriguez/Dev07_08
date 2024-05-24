using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Okane.Storage.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToExpenses : Migration
    {
        private const string ExpensesTable = "Expenses";
        private const string CategoryIdColumn = "CategoryId";

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: ExpensesTable);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: ExpensesTable,
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: CategoryIdColumn,
                table: ExpensesTable,
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryId",
                table: ExpensesTable,
                column: CategoryIdColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Categories_CategoryId",
                table: ExpensesTable,
                column: CategoryIdColumn,
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Categories_CategoryId",
                table: ExpensesTable);

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CategoryId",
                table: ExpensesTable);

            migrationBuilder.DropColumn(
                name: CategoryIdColumn,
                table: ExpensesTable);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: ExpensesTable,
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: ExpensesTable,
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
