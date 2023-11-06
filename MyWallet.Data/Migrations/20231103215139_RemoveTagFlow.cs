using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWallet.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTagFlow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Incomes",
                type: "VARCHAR(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Expenses",
                type: "VARCHAR(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Expenses");

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpenseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IncomeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tags_Incomes_IncomeId",
                        column: x => x.IncomeId,
                        principalTable: "Incomes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ExpenseId",
                table: "Tags",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_IncomeId",
                table: "Tags",
                column: "IncomeId");
        }
    }
}
