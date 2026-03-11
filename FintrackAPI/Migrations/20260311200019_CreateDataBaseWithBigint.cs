using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FintrackAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateDataBaseWithBigint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CAT_categoria",
                columns: table => new
                {
                    cat_id_categoria = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cat_nm_nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cat_ds_descricao = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAT_categoria", x => x.cat_id_categoria);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TPT_tipo_transacao",
                columns: table => new
                {
                    tpt_id_tipo_transacao = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tpt_nm_nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tpt_ds_descricao = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPT_tipo_transacao", x => x.tpt_id_tipo_transacao);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TRA_transacao",
                columns: table => new
                {
                    tra_id_transacao = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tra_nm_titulo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tra_vl_valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tra_dt_data = table.Column<DateOnly>(type: "date", nullable: false),
                    tra_id_categoria = table.Column<long>(type: "bigint", nullable: false),
                    tra_id_tipo_transacao = table.Column<long>(type: "bigint", nullable: false),
                    tra_fl_credito = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    tra_fl_recorrente = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRA_transacao", x => x.tra_id_transacao);
                    table.ForeignKey(
                        name: "FK_TRA_transacao_CAT_categoria_tra_id_categoria",
                        column: x => x.tra_id_categoria,
                        principalTable: "CAT_categoria",
                        principalColumn: "cat_id_categoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TRA_transacao_TPT_tipo_transacao_tra_id_tipo_transacao",
                        column: x => x.tra_id_tipo_transacao,
                        principalTable: "TPT_tipo_transacao",
                        principalColumn: "tpt_id_tipo_transacao",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "CAT_categoria",
                columns: new[] { "cat_id_categoria", "cat_ds_descricao", "cat_nm_nome" },
                values: new object[,]
                {
                    { 1000000001L, "Supermercado, padaria, restaurantes", "Alimentação" },
                    { 1000000002L, "Ônibus, metrô, combustível, apps de transporte", "Transporte" },
                    { 1000000003L, "Recebimento mensal da empresa", "Salário" }
                });

            migrationBuilder.InsertData(
                table: "TPT_tipo_transacao",
                columns: new[] { "tpt_id_tipo_transacao", "tpt_ds_descricao", "tpt_nm_nome" },
                values: new object[,]
                {
                    { 1000000001L, "Saídas de dinheiro e pagamentos", "Despesa" },
                    { 1000000002L, "Entradas de dinheiro e ganhos", "Receita" },
                    { 1000000003L, "Movimentação entre contas", "Transferência" }
                });

            migrationBuilder.InsertData(
                table: "TRA_transacao",
                columns: new[] { "tra_id_transacao", "tra_id_categoria", "tra_dt_data", "tra_fl_credito", "tra_fl_recorrente", "tra_id_tipo_transacao", "tra_nm_titulo", "tra_vl_valor" },
                values: new object[,]
                {
                    { 1000000001L, 1000000001L, new DateOnly(2026, 3, 5), true, false, 1000000001L, "Compra no Supermercado", 350.75m },
                    { 1000000002L, 1000000003L, new DateOnly(2026, 3, 1), false, true, 1000000002L, "Pagamento Mensal", 5000.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TRA_transacao_tra_id_categoria",
                table: "TRA_transacao",
                column: "tra_id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_TRA_transacao_tra_id_tipo_transacao",
                table: "TRA_transacao",
                column: "tra_id_tipo_transacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TRA_transacao");

            migrationBuilder.DropTable(
                name: "CAT_categoria");

            migrationBuilder.DropTable(
                name: "TPT_tipo_transacao");
        }
    }
}
