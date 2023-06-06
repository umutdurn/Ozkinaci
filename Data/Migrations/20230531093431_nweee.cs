using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class nweee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Advert",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Advert_EquipmentId",
                table: "Advert",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advert_Equipment_EquipmentId",
                table: "Advert",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advert_Equipment_EquipmentId",
                table: "Advert");

            migrationBuilder.DropIndex(
                name: "IX_Advert_EquipmentId",
                table: "Advert");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Advert");
        }
    }
}
