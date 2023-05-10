using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ndndnd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Categories_CategoryId",
                table: "CarModels");

            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Categories_CategoryId1",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_CategoryId1",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "CarModels");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Categories_CategoryId",
                table: "CarModels",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Categories_CategoryId",
                table: "CarModels");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "CarModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_CategoryId1",
                table: "CarModels",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Categories_CategoryId",
                table: "CarModels",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Categories_CategoryId1",
                table: "CarModels",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
