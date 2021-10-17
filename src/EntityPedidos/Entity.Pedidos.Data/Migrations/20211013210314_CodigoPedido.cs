using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Pedidos.Data.Migrations
{
    public partial class CodigoPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameTable(
                name: "Enderecos",
                newName: "enderecos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_enderecos",
                table: "enderecos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_pedidos_enderecos_endereco_id",
                table: "pedidos",
                column: "endereco_id",
                principalTable: "enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedidos_enderecos_endereco_id",
                table: "pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_enderecos",
                table: "enderecos");

            migrationBuilder.RenameTable(
                name: "enderecos",
                newName: "Enderecos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_pedidos_Enderecos_endereco_id",
                table: "pedidos",
                column: "endereco_id",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
