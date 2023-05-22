using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addgallery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advert",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarModelId = table.Column<int>(type: "int", nullable: false),
                    Gear = table.Column<int>(type: "int", nullable: false),
                    Fuel = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Km = table.Column<float>(type: "real", nullable: false),
                    MaxSpeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To0100 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tork = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmptyWeight = table.Column<float>(type: "real", nullable: false),
                    FuelConsumption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CylinderVolume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CylinderNumber = table.Column<int>(type: "int", nullable: false),
                    ValveNumber = table.Column<int>(type: "int", nullable: false),
                    CaseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnginePower = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfTransfer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advert_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Galleries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvertId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Galleries_Advert_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Advert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advert_CarModelId",
                table: "Advert",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Galleries_AdvertId",
                table: "Galleries",
                column: "AdvertId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Galleries");

            migrationBuilder.DropTable(
                name: "Advert");
        }
    }
}
