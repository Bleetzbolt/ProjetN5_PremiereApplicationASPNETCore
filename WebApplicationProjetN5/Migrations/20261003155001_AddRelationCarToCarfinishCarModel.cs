using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationProjetN5.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationCarToCarfinishCarModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarFinishs_CarFinishId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_UserId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_Cars_CarId",
                table: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_Visitors_CarId",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Visitors");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CarFinishId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "CarModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarFinishs_CarFinishId",
                table: "Cars",
                column: "CarFinishId",
                principalTable: "CarFinishs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_UserId",
                table: "Cars",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarFinishs_CarFinishId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_UserId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "CarModels");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Visitors",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CarFinishId",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_CarId",
                table: "Visitors",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarFinishs_CarFinishId",
                table: "Cars",
                column: "CarFinishId",
                principalTable: "CarFinishs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_UserId",
                table: "Cars",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_Cars_CarId",
                table: "Visitors",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }
    }
}
