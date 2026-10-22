using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationProjetN5.Migrations
{
    /// <inheritdoc />
    public partial class AddModifyReparationsToCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarReparation");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Reparations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Reparations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Reparations_CarId",
                table: "Reparations",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reparations_Cars_CarId",
                table: "Reparations",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reparations_Cars_CarId",
                table: "Reparations");

            migrationBuilder.DropIndex(
                name: "IX_Reparations_CarId",
                table: "Reparations");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Reparations");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Reparations");

            migrationBuilder.CreateTable(
                name: "CarReparation",
                columns: table => new
                {
                    CarsId = table.Column<int>(type: "int", nullable: false),
                    ReparationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarReparation", x => new { x.CarsId, x.ReparationsId });
                    table.ForeignKey(
                        name: "FK_CarReparation_Cars_CarsId",
                        column: x => x.CarsId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarReparation_Reparations_ReparationsId",
                        column: x => x.ReparationsId,
                        principalTable: "Reparations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarReparation_ReparationsId",
                table: "CarReparation",
                column: "ReparationsId");
        }
    }
}
