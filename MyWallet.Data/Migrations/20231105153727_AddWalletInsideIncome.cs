using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWallet.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddWalletInsideIncome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WalletId",
                table: "Incomes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_WalletId",
                table: "Incomes",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_Wallets_WalletId",
                table: "Incomes",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_Wallets_WalletId",
                table: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Incomes_WalletId",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "WalletId",
                table: "Incomes");
        }
    }
}
