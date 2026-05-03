using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class DodanieZawodnikow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zawodnicy",
                columns: table => new
                {
                    ZawodnikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nrKoszulki = table.Column<byte>(type: "TINYINT", nullable: false),
                    kondycja = table.Column<decimal>(type: "NUMERIC(2,1)", nullable: false),
                    czyKontuzja = table.Column<bool>(type: "bit", nullable: false),
                    imie = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zawodnicy", x => x.ZawodnikId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zawodnicy");
        }
    }
}
