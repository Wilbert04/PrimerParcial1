using Microsoft.EntityFrameworkCore.Migrations;

namespace PrimerParcialAplicada.Migrations
{
    public partial class ProductoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "productoTB",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    Existencia = table.Column<int>(nullable: false),
                    Costo = table.Column<decimal>(nullable: false),
                    ValorInventario = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productoTB", x => x.ProductoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productoTB");
        }
    }
}
