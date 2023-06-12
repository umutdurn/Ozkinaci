using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class neweeeexp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expertiz_Advert_AdvertId",
                table: "Expertiz");

            migrationBuilder.DropIndex(
                name: "IX_Expertiz_AdvertId",
                table: "Expertiz");

            migrationBuilder.DropColumn(
                name: "AdvertId",
                table: "Expertiz");

            migrationBuilder.AddColumn<int>(
                name: "ExpertizId",
                table: "Advert",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Advert_ExpertizId",
                table: "Advert",
                column: "ExpertizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advert_Expertiz_ExpertizId",
                table: "Advert",
                column: "ExpertizId",
                principalTable: "Expertiz",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advert_Expertiz_ExpertizId",
                table: "Advert");

            migrationBuilder.DropIndex(
                name: "IX_Advert_ExpertizId",
                table: "Advert");

            migrationBuilder.DropColumn(
                name: "ExpertizId",
                table: "Advert");

            migrationBuilder.AddColumn<int>(
                name: "AdvertId",
                table: "Expertiz",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Expertiz_AdvertId",
                table: "Expertiz",
                column: "AdvertId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expertiz_Advert_AdvertId",
                table: "Expertiz",
                column: "AdvertId",
                principalTable: "Advert",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
