using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Pedidos.Data.Migrations
{
    public partial class CuponsePedidoItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CupomDesconto",
                columns: table => new
                {
                    CupomDescontoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodigoCupom = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PercentualDesconto = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    ValorDesconto = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    TipoCupomDesconto = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AplicadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataExpiracao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Aplicado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CupomDesconto", x => x.CupomDescontoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "pedidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cliente_id = table.Column<int>(type: "int", nullable: false),
                    endereco_id = table.Column<int>(type: "int", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    valor_total = table.Column<double>(type: "double", nullable: false),
                    data = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    VoucherId = table.Column<int>(type: "int", nullable: false),
                    PedidoStatus = table.Column<int>(type: "int", nullable: false),
                    CupomDescontoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidos", x => x.id);
                    table.ForeignKey(
                        name: "FK_pedidos_CupomDesconto_CupomDescontoId",
                        column: x => x.CupomDescontoId,
                        principalTable: "CupomDesconto",
                        principalColumn: "CupomDescontoId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "PedidoItem",
                columns: table => new
                {
                    PedidoItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    NomeProduto = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItem", x => x.PedidoItemId);
                    table.ForeignKey(
                        name: "FK_PedidoItem_pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "pedidos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_PedidoId",
                table: "PedidoItem",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_cliente_id",
                table: "pedidos",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_CupomDescontoId",
                table: "pedidos",
                column: "CupomDescontoId");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_endereco_id",
                table: "pedidos",
                column: "endereco_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoItem");

            migrationBuilder.DropTable(
                name: "pedidos");

            migrationBuilder.DropTable(
                name: "CupomDesconto");
        }
    }
}
