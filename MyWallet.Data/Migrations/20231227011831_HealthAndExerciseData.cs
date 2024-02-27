using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWallet.Data.Migrations
{
    /// <inheritdoc />
    public partial class HealthAndExerciseData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    HealthDate = table.Column<DateTime>(nullable: false),
                    Systolic = table.Column<int>(nullable: false),
                    Diastolic = table.Column<int>(nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    SleepQuality = table.Column<int>(nullable: false), 
                    IsTired = table.Column<bool>(nullable: false),
                    StomachSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    ExerciseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Distance = table.Column<double>(nullable: true),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    Intensity = table.Column<int>(nullable: false), 
                    ExerciseType = table.Column<int>(nullable: false),
                    Repetitions = table.Column<int>(nullable: true),
                    Tags = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthData");

            migrationBuilder.DropTable(
                name: "Exercises");
        }
    }
}
