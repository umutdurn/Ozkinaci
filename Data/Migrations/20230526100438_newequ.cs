using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class newequ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Equipment_EquipmentId",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_EquipmentId",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "CarModels");

            migrationBuilder.AddColumn<int>(
                name: "CarModelId",
                table: "Equipment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_CarModelId",
                table: "Equipment",
                column: "CarModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_CarModels_CarModelId",
                table: "Equipment",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_CarModels_CarModelId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_CarModelId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "CarModelId",
                table: "Equipment");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "CarModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_EquipmentId",
                table: "CarModels",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Equipment_EquipmentId",
                table: "CarModels",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id");
        }
    }
}
