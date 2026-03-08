using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FintrackAPI.Migrations
{
    /// <inheritdoc />
    public partial class AjusteTabelaTransacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "tra_dt_data",
                table: "TRA_transacao",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.UpdateData(
                table: "TRA_transacao",
                keyColumn: "tra_id_transacao",
                keyValue: 1000000001,
                column: "tra_dt_data",
                value: new DateOnly(2026, 3, 5));

            migrationBuilder.UpdateData(
                table: "TRA_transacao",
                keyColumn: "tra_id_transacao",
                keyValue: 1000000002,
                column: "tra_dt_data",
                value: new DateOnly(2026, 3, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "tra_dt_data",
                table: "TRA_transacao",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "TRA_transacao",
                keyColumn: "tra_id_transacao",
                keyValue: 1000000001,
                column: "tra_dt_data",
                value: new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TRA_transacao",
                keyColumn: "tra_id_transacao",
                keyValue: 1000000002,
                column: "tra_dt_data",
                value: new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
