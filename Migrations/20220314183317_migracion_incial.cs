using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pablo_Burgos_Ap1_p2.Migrations
{
    public partial class migracion_incial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 35, nullable: false),
                    FechaDeVencimiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Existencia = table.Column<int>(type: "INTEGER", nullable: false),
                    Peso = table.Column<float>(type: "REAL", nullable: false),
                    Costo = table.Column<float>(type: "REAL", nullable: false),
                    ValorInventario = table.Column<float>(type: "REAL", nullable: false),
                    Precio = table.Column<float>(type: "REAL", nullable: false),
                    Ganancia = table.Column<int>(type: "INTEGER", nullable: false),
                    PesoTotal = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "ProductosDetalles",
                columns: table => new
                {
                    ProductosDetallesId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 35, nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosDetalles", x => x.ProductosDetallesId);
                    table.ForeignKey(
                        name: "FK_ProductosDetalles_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductosEmpacados",
                columns: table => new
                {
                    ProductoEmpacadosId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductosDetallesId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Concepto = table.Column<string>(type: "TEXT", maxLength: 35, nullable: false),
                    cantidadUtilizados = table.Column<int>(type: "INTEGER", nullable: false),
                    cantidadProducidos = table.Column<int>(type: "INTEGER", nullable: false),
                    _productoProductoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosEmpacados", x => x.ProductoEmpacadosId);
                    table.ForeignKey(
                        name: "FK_ProductosEmpacados_Productos__productoProductoId",
                        column: x => x._productoProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                    table.ForeignKey(
                        name: "FK_ProductosEmpacados_ProductosDetalles_ProductosDetallesId",
                        column: x => x.ProductosDetallesId,
                        principalTable: "ProductosDetalles",
                        principalColumn: "ProductosDetallesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductosEmpacadosDetalle",
                columns: table => new
                {
                    ProductoEmpacadosDetallesId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductoEmpacadosId = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Peso = table.Column<float>(type: "REAL", nullable: false),
                    _productoProductoId = table.Column<int>(type: "INTEGER", nullable: true),
                    _productosEmpacadosDetalleProductoEmpacadosDetallesId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosEmpacadosDetalle", x => x.ProductoEmpacadosDetallesId);
                    table.ForeignKey(
                        name: "FK_ProductosEmpacadosDetalle_Productos__productoProductoId",
                        column: x => x._productoProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                    table.ForeignKey(
                        name: "FK_ProductosEmpacadosDetalle_ProductosEmpacados_ProductoEmpacadosId",
                        column: x => x.ProductoEmpacadosId,
                        principalTable: "ProductosEmpacados",
                        principalColumn: "ProductoEmpacadosId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductosEmpacadosDetalle_ProductosEmpacadosDetalle__productosEmpacadosDetalleProductoEmpacadosDetallesId",
                        column: x => x._productosEmpacadosDetalleProductoEmpacadosDetallesId,
                        principalTable: "ProductosEmpacadosDetalle",
                        principalColumn: "ProductoEmpacadosDetallesId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductosDetalles_ProductoId",
                table: "ProductosDetalles",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosEmpacados__productoProductoId",
                table: "ProductosEmpacados",
                column: "_productoProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosEmpacados_ProductosDetallesId",
                table: "ProductosEmpacados",
                column: "ProductosDetallesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosEmpacadosDetalle__productoProductoId",
                table: "ProductosEmpacadosDetalle",
                column: "_productoProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosEmpacadosDetalle__productosEmpacadosDetalleProductoEmpacadosDetallesId",
                table: "ProductosEmpacadosDetalle",
                column: "_productosEmpacadosDetalleProductoEmpacadosDetallesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosEmpacadosDetalle_ProductoEmpacadosId",
                table: "ProductosEmpacadosDetalle",
                column: "ProductoEmpacadosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductosEmpacadosDetalle");

            migrationBuilder.DropTable(
                name: "ProductosEmpacados");

            migrationBuilder.DropTable(
                name: "ProductosDetalles");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
