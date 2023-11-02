using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWallet.Data.Migrations
{
    /// <inheritdoc />
    public partial class Expense_Comments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Wallet_WalletId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallet",
                table: "Wallets");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Incomes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Expenses",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Wallets_WalletId",
                table: "Expenses",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Wallets_WalletId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Expenses");

            migrationBuilder.RenameTable(
                name: "Wallets",
                newName: "Wallets");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Incomes",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Expenses",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallet",
                table: "Wallets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Wallet_WalletId",
                table: "Expenses",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id");
        }
    }
}
