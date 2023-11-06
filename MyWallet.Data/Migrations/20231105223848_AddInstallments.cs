using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWallet.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddInstallments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Renomear o campo Installments para InstallmentsQuantity
            migrationBuilder.RenameColumn(
                name: "Installments",
                table: "Incomes",
                newName: "InstallmentsQuantity");

            // Adicionar um novo campo Installment
            migrationBuilder.AddColumn<int>(
                name: "Installment",
                table: "Incomes",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Desfazer a adição do campo Installment
            migrationBuilder.DropColumn(
                name: "Installment",
                table: "Incomes");

            // Renomear o campo InstallmentsQuantity de volta para Installments
            migrationBuilder.RenameColumn(
                name: "InstallmentsQuantity",
                table: "Incomes",
                newName: "Installments");
        }
    }
}
