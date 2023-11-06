using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWallet.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameInstallments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Installments",
                table: "Expenses",
                newName: "InstallmentsQuantity");

            migrationBuilder.AddColumn<int>(
                name: "Installment",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Installment",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "InstallmentsQuantity",
                table: "Expenses",
                newName: "Installments");
        }
    }
}
