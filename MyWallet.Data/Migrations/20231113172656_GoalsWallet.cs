using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWallet.Data.Migrations
{
    /// <inheritdoc />
    public partial class GoalsWallet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.RenameColumn(
            //    name: "Installments",
            //    table: "Incomes",
            //    newName: "InstallmentsQuantity");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingDay",
                table: "Wallets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WalletType",
                table: "Wallets",
                type: "int",
                nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "Installment",
            //    table: "Incomes",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShoppingDay",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "WalletType",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "Installment",
                table: "Incomes");

            migrationBuilder.RenameColumn(
                name: "InstallmentsQuantity",
                table: "Incomes",
                newName: "Installments");
        }
    }
}
