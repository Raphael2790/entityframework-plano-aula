using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Pedidos.Data.Migrations
{
    public partial class deletandoforeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItems_pedidos_PedidoId",
                table: "PedidoItems");

            migrationBuilder.DropForeignKey(
                name: "FK_pedidos_CupomDescontos_CupomDescontoId",
                table: "pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoItems",
                table: "PedidoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CupomDescontos",
                table: "CupomDescontos");

            migrationBuilder.DropColumn(
                name: "VoucherId",
                table: "pedidos");

            migrationBuilder.RenameTable(
                name: "PedidoItems",
                newName: "pedidos_itens");

            migrationBuilder.RenameTable(
                name: "CupomDescontos",
                newName: "cupons_descontos");

            migrationBuilder.RenameColumn(
                name: "Desconto",
                table: "pedidos",
                newName: "desconto");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "pedidos",
                newName: "codigo");

            migrationBuilder.RenameColumn(
                name: "data",
                table: "pedidos",
                newName: "data_pedido");

            migrationBuilder.RenameColumn(
                name: "PedidoStatus",
                table: "pedidos",
                newName: "pedido_status");

            migrationBuilder.RenameColumn(
                name: "CupomDescontoId",
                table: "pedidos",
                newName: "cupom_desconto_id");

            migrationBuilder.RenameIndex(
                name: "IX_pedidos_CupomDescontoId",
                table: "pedidos",
                newName: "IX_pedido_cupom_desconto_id");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "enderecos",
                newName: "numero");

            migrationBuilder.RenameColumn(
                name: "Logradouro",
                table: "enderecos",
                newName: "logradouro");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "enderecos",
                newName: "estado");

            migrationBuilder.RenameColumn(
                name: "Complemento",
                table: "enderecos",
                newName: "complemento");

            migrationBuilder.RenameColumn(
                name: "Cidade",
                table: "enderecos",
                newName: "cidade");

            migrationBuilder.RenameColumn(
                name: "Cep",
                table: "enderecos",
                newName: "cep");

            migrationBuilder.RenameColumn(
                name: "Bairro",
                table: "enderecos",
                newName: "bairro");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "enderecos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "pedidos_itens",
                newName: "quantidade");

            migrationBuilder.RenameColumn(
                name: "ValorUnitario",
                table: "pedidos_itens",
                newName: "valor_unitario");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "pedidos_itens",
                newName: "produto_id");

            migrationBuilder.RenameColumn(
                name: "PedidoId",
                table: "pedidos_itens",
                newName: "pedido_id");

            migrationBuilder.RenameColumn(
                name: "NomeProduto",
                table: "pedidos_itens",
                newName: "nome_produto");

            migrationBuilder.RenameColumn(
                name: "PedidoItemId",
                table: "pedidos_itens",
                newName: "pedido_item_id");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoItems_PedidoId",
                table: "pedidos_itens",
                newName: "IX_pedidos_itens_pedido_id");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "cupons_descontos",
                newName: "quantidade");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "cupons_descontos",
                newName: "ativo");

            migrationBuilder.RenameColumn(
                name: "Aplicado",
                table: "cupons_descontos",
                newName: "aplicado");

            migrationBuilder.RenameColumn(
                name: "ValorDesconto",
                table: "cupons_descontos",
                newName: "valor_desconto");

            migrationBuilder.RenameColumn(
                name: "TipoCupomDesconto",
                table: "cupons_descontos",
                newName: "tipo_cupom_desconto");

            migrationBuilder.RenameColumn(
                name: "PercentualDesconto",
                table: "cupons_descontos",
                newName: "percentual_desconto");

            migrationBuilder.RenameColumn(
                name: "DataExpiracao",
                table: "cupons_descontos",
                newName: "data_expiracao");

            migrationBuilder.RenameColumn(
                name: "CriadoEm",
                table: "cupons_descontos",
                newName: "criado_em");

            migrationBuilder.RenameColumn(
                name: "CodigoCupom",
                table: "cupons_descontos",
                newName: "codigo_cupom");

            migrationBuilder.RenameColumn(
                name: "AplicadoEm",
                table: "cupons_descontos",
                newName: "aplicado_em");

            migrationBuilder.RenameColumn(
                name: "CupomDescontoId",
                table: "cupons_descontos",
                newName: "cupom_desconto_id");

            migrationBuilder.AlterColumn<decimal>(
                name: "valor_total",
                table: "pedidos",
                type: "decimal(12,2)",
                precision: 12,
                scale: 2,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<decimal>(
                name: "desconto",
                table: "pedidos",
                type: "decimal(12,2)",
                precision: 12,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<string>(
                name: "codigo",
                table: "pedidos",
                type: "varchar(150)",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "numero",
                table: "enderecos",
                type: "varchar(30)",
                nullable: false,
                defaultValue: "",
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "logradouro",
                table: "enderecos",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "estado",
                table: "enderecos",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "",
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "complemento",
                table: "enderecos",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "cidade",
                table: "enderecos",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "",
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "cep",
                table: "enderecos",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "bairro",
                table: "enderecos",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "",
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<decimal>(
                name: "valor_unitario",
                table: "pedidos_itens",
                type: "decimal(12,2)",
                precision: 12,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<string>(
                name: "nome_produto",
                table: "pedidos_itens",
                type: "varchar(250)",
                nullable: false,
                defaultValue: "",
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<sbyte>(
                name: "ativo",
                table: "cupons_descontos",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<sbyte>(
                name: "aplicado",
                table: "cupons_descontos",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<decimal>(
                name: "valor_desconto",
                table: "cupons_descontos",
                type: "decimal(12,2)",
                precision: 12,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "percentual_desconto",
                table: "cupons_descontos",
                type: "decimal(12,2)",
                precision: 12,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "codigo_cupom",
                table: "cupons_descontos",
                type: "varchar(255)",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pedidos_itens",
                table: "pedidos_itens",
                column: "pedido_item_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cupons_descontos_id",
                table: "cupons_descontos",
                column: "cupom_desconto_id");

            migrationBuilder.CreateIndex(
                name: "IX_PK_enderecoid",
                table: "enderecos",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_itens_produto_id",
                table: "pedidos_itens",
                column: "produto_id");

            migrationBuilder.AddForeignKey(
                name: "FK_pedidos_cupons_descontos_cupom_desconto_id",
                table: "pedidos",
                column: "cupom_desconto_id",
                principalTable: "cupons_descontos",
                principalColumn: "cupom_desconto_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_pedido_itens_pedidos_pedido_id",
                table: "pedidos_itens",
                column: "pedido_id",
                principalTable: "pedidos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedidos_cupons_descontos_cupom_desconto_id",
                table: "pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_pedido_itens_pedidos_pedido_id",
                table: "pedidos_itens");

            migrationBuilder.DropIndex(
                name: "IX_PK_enderecoid",
                table: "enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pedidos_itens",
                table: "pedidos_itens");

            migrationBuilder.DropIndex(
                name: "IX_pedidos_itens_produto_id",
                table: "pedidos_itens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cupons_descontos_id",
                table: "cupons_descontos");

            migrationBuilder.RenameTable(
                name: "pedidos_itens",
                newName: "PedidoItems");

            migrationBuilder.RenameTable(
                name: "cupons_descontos",
                newName: "CupomDescontos");

            migrationBuilder.RenameColumn(
                name: "desconto",
                table: "pedidos",
                newName: "Desconto");

            migrationBuilder.RenameColumn(
                name: "codigo",
                table: "pedidos",
                newName: "Codigo");

            migrationBuilder.RenameColumn(
                name: "pedido_status",
                table: "pedidos",
                newName: "PedidoStatus");

            migrationBuilder.RenameColumn(
                name: "data_pedido",
                table: "pedidos",
                newName: "data");

            migrationBuilder.RenameColumn(
                name: "cupom_desconto_id",
                table: "pedidos",
                newName: "CupomDescontoId");

            migrationBuilder.RenameIndex(
                name: "IX_pedido_cupom_desconto_id",
                table: "pedidos",
                newName: "IX_pedidos_CupomDescontoId");

            migrationBuilder.RenameColumn(
                name: "numero",
                table: "enderecos",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "logradouro",
                table: "enderecos",
                newName: "Logradouro");

            migrationBuilder.RenameColumn(
                name: "estado",
                table: "enderecos",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "complemento",
                table: "enderecos",
                newName: "Complemento");

            migrationBuilder.RenameColumn(
                name: "cidade",
                table: "enderecos",
                newName: "Cidade");

            migrationBuilder.RenameColumn(
                name: "cep",
                table: "enderecos",
                newName: "Cep");

            migrationBuilder.RenameColumn(
                name: "bairro",
                table: "enderecos",
                newName: "Bairro");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "enderecos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "quantidade",
                table: "PedidoItems",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "valor_unitario",
                table: "PedidoItems",
                newName: "ValorUnitario");

            migrationBuilder.RenameColumn(
                name: "produto_id",
                table: "PedidoItems",
                newName: "ProdutoId");

            migrationBuilder.RenameColumn(
                name: "pedido_id",
                table: "PedidoItems",
                newName: "PedidoId");

            migrationBuilder.RenameColumn(
                name: "nome_produto",
                table: "PedidoItems",
                newName: "NomeProduto");

            migrationBuilder.RenameColumn(
                name: "pedido_item_id",
                table: "PedidoItems",
                newName: "PedidoItemId");

            migrationBuilder.RenameIndex(
                name: "IX_pedidos_itens_pedido_id",
                table: "PedidoItems",
                newName: "IX_PedidoItems_PedidoId");

            migrationBuilder.RenameColumn(
                name: "quantidade",
                table: "CupomDescontos",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "ativo",
                table: "CupomDescontos",
                newName: "Ativo");

            migrationBuilder.RenameColumn(
                name: "aplicado",
                table: "CupomDescontos",
                newName: "Aplicado");

            migrationBuilder.RenameColumn(
                name: "valor_desconto",
                table: "CupomDescontos",
                newName: "ValorDesconto");

            migrationBuilder.RenameColumn(
                name: "tipo_cupom_desconto",
                table: "CupomDescontos",
                newName: "TipoCupomDesconto");

            migrationBuilder.RenameColumn(
                name: "percentual_desconto",
                table: "CupomDescontos",
                newName: "PercentualDesconto");

            migrationBuilder.RenameColumn(
                name: "data_expiracao",
                table: "CupomDescontos",
                newName: "DataExpiracao");

            migrationBuilder.RenameColumn(
                name: "criado_em",
                table: "CupomDescontos",
                newName: "CriadoEm");

            migrationBuilder.RenameColumn(
                name: "codigo_cupom",
                table: "CupomDescontos",
                newName: "CodigoCupom");

            migrationBuilder.RenameColumn(
                name: "aplicado_em",
                table: "CupomDescontos",
                newName: "AplicadoEm");

            migrationBuilder.RenameColumn(
                name: "cupom_desconto_id",
                table: "CupomDescontos",
                newName: "CupomDescontoId");

            migrationBuilder.AlterColumn<double>(
                name: "valor_total",
                table: "pedidos",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,2)",
                oldPrecision: 12,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Desconto",
                table: "pedidos",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,2)",
                oldPrecision: 12,
                oldScale: 2);

            migrationBuilder.AlterColumn<int>(
                name: "Codigo",
                table: "pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AddColumn<int>(
                name: "VoucherId",
                table: "pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "enderecos",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(30)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "enderecos",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "enderecos",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(150)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "enderecos",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "enderecos",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(150)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "enderecos",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "enderecos",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(150)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorUnitario",
                table: "PedidoItems",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,2)",
                oldPrecision: 12,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "NomeProduto",
                table: "PedidoItems",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(250)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "CupomDescontos",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<bool>(
                name: "Aplicado",
                table: "CupomDescontos",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorDesconto",
                table: "CupomDescontos",
                type: "decimal(65,30)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,2)",
                oldPrecision: 12,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PercentualDesconto",
                table: "CupomDescontos",
                type: "decimal(65,30)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,2)",
                oldPrecision: 12,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoCupom",
                table: "CupomDescontos",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoItems",
                table: "PedidoItems",
                column: "PedidoItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CupomDescontos",
                table: "CupomDescontos",
                column: "CupomDescontoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItems_pedidos_PedidoId",
                table: "PedidoItems",
                column: "PedidoId",
                principalTable: "pedidos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pedidos_CupomDescontos_CupomDescontoId",
                table: "pedidos",
                column: "CupomDescontoId",
                principalTable: "CupomDescontos",
                principalColumn: "CupomDescontoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
