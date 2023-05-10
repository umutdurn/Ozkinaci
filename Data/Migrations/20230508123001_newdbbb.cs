using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class newdbbb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandModels_CarBrands_CarBrandId",
                table: "BrandModels");

            migrationBuilder.AddColumn<int>(
                name: "CarBrandId",
                table: "CarModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CarBrandId",
                table: "BrandModels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_CarBrandId",
                table: "CarModels",
                column: "CarBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandModels_CarBrands_CarBrandId",
                table: "BrandModels",
                column: "CarBrandId",
                principalTable: "CarBrands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_CarBrands_CarBrandId",
                table: "CarModels",
                column: "CarBrandId",
                principalTable: "CarBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandModels_CarBrands_CarBrandId",
                table: "BrandModels");

            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_CarBrands_CarBrandId",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_CarBrandId",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "CarBrandId",
                table: "CarModels");

            migrationBuilder.AlterColumn<int>(
                name: "CarBrandId",
                table: "BrandModels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BrandModels_CarBrands_CarBrandId",
                table: "BrandModels",
                column: "CarBrandId",
                principalTable: "CarBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
