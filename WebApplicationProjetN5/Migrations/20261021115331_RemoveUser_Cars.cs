using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationProjetN5.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUser_Cars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_UserId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_UserId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserId",
                table: "Cars",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_UserId",
                table: "Cars",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
