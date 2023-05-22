using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class newdbbbbbbb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "CarModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Equipment_EquipmentId",
                table: "CarModels");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_EquipmentId",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "CarModels");
        }
    }
}
