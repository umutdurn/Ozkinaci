using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class advertcolor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Advert");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Advert",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Advert_ColorId",
                table: "Advert",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advert_Color_ColorId",
                table: "Advert",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advert_Color_ColorId",
                table: "Advert");

            migrationBuilder.DropIndex(
                name: "IX_Advert_ColorId",
                table: "Advert");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Advert");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Advert",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
