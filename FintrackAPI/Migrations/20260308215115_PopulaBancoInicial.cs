using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FintrackAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulaBancoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CAT_categoria",
                columns: new[] { "cat_id_categoria", "cat_ds_descricao", "cat_nm_nome" },
                values: new object[,]
                {
                    { 1000000001, "Supermercado, padaria, restaurantes", "Alimentação" },
                    { 1000000002, "Ônibus, metrô, combustível, apps de transporte", "Transporte" },
                    { 1000000003, "Recebimento mensal da empresa", "Salário" }
                });

            migrationBuilder.InsertData(
                table: "TPT_tipo_transacao",
                columns: new[] { "tpt_id_tipo_transacao", "tpt_ds_descricao", "tpt_nm_nome" },
                values: new object[,]
                {
                    { 1000000001, "Saídas de dinheiro e pagamentos", "Despesa" },
                    { 1000000002, "Entradas de dinheiro e ganhos", "Receita" },
                    { 1000000003, "Movimentação entre contas", "Transferência" }
                });

            migrationBuilder.InsertData(
                table: "TRA_transacao",
                columns: new[] { "tra_id_transacao", "tra_id_categoria", "tra_dt_data", "tra_fl_credito", "tra_fl_recorrente", "tra_id_tipo_transacao", "tra_nm_titulo", "tra_vl_valor" },
                values: new object[,]
                {
                    { 1000000001, 1000000001, new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, 1000000001, "Compra no Supermercado", 350.75m },
                    { 1000000002, 1000000003, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, 1000000002, "Pagamento Mensal", 5000.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CAT_categoria",
                keyColumn: "cat_id_categoria",
                keyValue: 1000000002);

            migrationBuilder.DeleteData(
                table: "TPT_tipo_transacao",
                keyColumn: "tpt_id_tipo_transacao",
                keyValue: 1000000003);

            migrationBuilder.DeleteData(
                table: "TRA_transacao",
                keyColumn: "tra_id_transacao",
                keyValue: 1000000001);

            migrationBuilder.DeleteData(
                table: "TRA_transacao",
                keyColumn: "tra_id_transacao",
                keyValue: 1000000002);

            migrationBuilder.DeleteData(
                table: "CAT_categoria",
                keyColumn: "cat_id_categoria",
                keyValue: 1000000001);

            migrationBuilder.DeleteData(
                table: "CAT_categoria",
                keyColumn: "cat_id_categoria",
                keyValue: 1000000003);

            migrationBuilder.DeleteData(
                table: "TPT_tipo_transacao",
                keyColumn: "tpt_id_tipo_transacao",
                keyValue: 1000000001);

            migrationBuilder.DeleteData(
                table: "TPT_tipo_transacao",
                keyColumn: "tpt_id_tipo_transacao",
                keyValue: 1000000002);
        }
    }
}
