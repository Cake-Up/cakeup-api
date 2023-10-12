using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CakeUpERP.Infra.Data.Migrations
{
    public partial class AdicionandoOrcamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "observacao_cliente",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.CreateTable(
                name: "ingrediente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustoUnitario = table.Column<float>(type: "float", precision: 5, scale: 2, nullable: false),
                    QtdPorEmbalagem = table.Column<int>(type: "int", nullable: false),
                    TipoEmbalagem = table.Column<int>(type: "int", nullable: false),
                    Validade = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdUnidadeMedida = table.Column<int>(type: "int", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingrediente", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orcamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataOrcamento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataExpiracao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataEvento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CodReferencia = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Titulo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdStatusOrcamento = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orcamento_cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "receita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustoReceita = table.Column<float>(type: "float", precision: 5, scale: 2, nullable: false),
                    Rendimento = table.Column<int>(type: "int", nullable: false),
                    EndereçoImagem = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Peso = table.Column<float>(type: "float", nullable: false),
                    ModoDePreparo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataPreparo = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receita", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataPedido = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataEvento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ValorTotal = table.Column<float>(type: "float", nullable: false),
                    IdStatusPedido = table.Column<int>(type: "int", nullable: false),
                    IdOrcamento = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pedido_cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedido_Orcamento_IdOrcamento",
                        column: x => x.IdOrcamento,
                        principalTable: "Orcamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "itensOrcamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdIngrediente = table.Column<int>(type: "int", nullable: true),
                    IdReceita = table.Column<int>(type: "int", nullable: true),
                    IdStatus = table.Column<int>(type: "int", nullable: false),
                    OrcamentoEntityId = table.Column<int>(type: "int", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itensOrcamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_itensOrcamento_ingrediente_IdIngrediente",
                        column: x => x.IdIngrediente,
                        principalTable: "ingrediente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_itensOrcamento_Orcamento_OrcamentoEntityId",
                        column: x => x.OrcamentoEntityId,
                        principalTable: "Orcamento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_itensOrcamento_receita_IdReceita",
                        column: x => x.IdReceita,
                        principalTable: "receita",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movimentacoesIngredientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataMovimentacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdReceita = table.Column<int>(type: "int", nullable: true),
                    IdIngrediente = table.Column<int>(type: "int", nullable: true),
                    QtdProduto = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<float>(type: "float", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimentacoesIngredientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movimentacoesIngredientes_ingrediente_IdIngrediente",
                        column: x => x.IdIngrediente,
                        principalTable: "ingrediente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_movimentacoesIngredientes_receita_IdReceita",
                        column: x => x.IdReceita,
                        principalTable: "receita",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rlIngredientesReceita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdReceita = table.Column<int>(type: "int", nullable: false),
                    IdIngrediente = table.Column<int>(type: "int", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rlIngredientesReceita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rlIngredientesReceita_ingrediente_IdIngrediente",
                        column: x => x.IdIngrediente,
                        principalTable: "ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rlIngredientesReceita_receita_IdReceita",
                        column: x => x.IdReceita,
                        principalTable: "receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "utensiliosEEquipamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustoCompra = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DataCompra = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TipoUtensilio = table.Column<int>(type: "int", nullable: false),
                    IdReceita = table.Column<int>(type: "int", nullable: false),
                    ReceitaId = table.Column<int>(type: "int", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_utensiliosEEquipamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_utensiliosEEquipamentos_receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rlUtensiliosReceita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdReceita = table.Column<int>(type: "int", nullable: false),
                    IdUtensilio = table.Column<int>(type: "int", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rlUtensiliosReceita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rlUtensiliosReceita_receita_IdReceita",
                        column: x => x.IdReceita,
                        principalTable: "receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rlUtensiliosReceita_utensiliosEEquipamentos_IdUtensilio",
                        column: x => x.IdUtensilio,
                        principalTable: "utensiliosEEquipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "companhia",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2023, 10, 12, 1, 40, 27, 661, DateTimeKind.Local).AddTicks(1702));

            migrationBuilder.CreateIndex(
                name: "IX_itensOrcamento_IdIngrediente",
                table: "itensOrcamento",
                column: "IdIngrediente");

            migrationBuilder.CreateIndex(
                name: "IX_itensOrcamento_IdReceita",
                table: "itensOrcamento",
                column: "IdReceita");

            migrationBuilder.CreateIndex(
                name: "IX_itensOrcamento_OrcamentoEntityId",
                table: "itensOrcamento",
                column: "OrcamentoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoesIngredientes_IdIngrediente",
                table: "movimentacoesIngredientes",
                column: "IdIngrediente");

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoesIngredientes_IdReceita",
                table: "movimentacoesIngredientes",
                column: "IdReceita");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_CodReferencia",
                table: "Orcamento",
                column: "CodReferencia",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_IdCliente",
                table: "Orcamento",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_IdCliente",
                table: "pedido",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_IdOrcamento",
                table: "pedido",
                column: "IdOrcamento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rlIngredientesReceita_IdIngrediente",
                table: "rlIngredientesReceita",
                column: "IdIngrediente");

            migrationBuilder.CreateIndex(
                name: "IX_rlIngredientesReceita_IdReceita",
                table: "rlIngredientesReceita",
                column: "IdReceita");

            migrationBuilder.CreateIndex(
                name: "IX_rlUtensiliosReceita_IdReceita",
                table: "rlUtensiliosReceita",
                column: "IdReceita");

            migrationBuilder.CreateIndex(
                name: "IX_rlUtensiliosReceita_IdUtensilio",
                table: "rlUtensiliosReceita",
                column: "IdUtensilio");

            migrationBuilder.CreateIndex(
                name: "IX_utensiliosEEquipamentos_ReceitaId",
                table: "utensiliosEEquipamentos",
                column: "ReceitaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itensOrcamento");

            migrationBuilder.DropTable(
                name: "movimentacoesIngredientes");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "rlIngredientesReceita");

            migrationBuilder.DropTable(
                name: "rlUtensiliosReceita");

            migrationBuilder.DropTable(
                name: "Orcamento");

            migrationBuilder.DropTable(
                name: "ingrediente");

            migrationBuilder.DropTable(
                name: "utensiliosEEquipamentos");

            migrationBuilder.DropTable(
                name: "receita");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "observacao_cliente",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.UpdateData(
                table: "companhia",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2023, 6, 25, 16, 54, 17, 687, DateTimeKind.Local).AddTicks(4832));
        }
    }
}
