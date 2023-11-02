using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWallet.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddExpenseDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Incomes",
                type: "VARCHAR(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Expenses",
                type: "VARCHAR(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpenseDate",
                table: "Expenses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "ExpenseDate",
                table: "Expenses");

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(200)",
                oldMaxLength: 200);
        }
    }
}
