using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class newexp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expertiz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertId = table.Column<int>(type: "int", nullable: false),
                    OnTampon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnSagCamurluk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnSolCamurluk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kaput = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnSagKapi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnSolKapi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArkaSagKapi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArkaSolKapi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tavan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArkaSolCamurluk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArkaSagCamurluk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BagajKapagi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArkaTampon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expertiz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expertiz_Advert_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Advert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expertiz_AdvertId",
                table: "Expertiz",
                column: "AdvertId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expertiz");
        }
    }
}
