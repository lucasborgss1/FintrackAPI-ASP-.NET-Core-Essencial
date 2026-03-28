using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FintrackAPI.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaTransacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TRA_transacao_CAT_categoria_tra_id_categoria",
                table: "TRA_transacao");

            migrationBuilder.AlterColumn<long>(
                name: "tra_id_categoria",
                table: "TRA_transacao",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_TRA_transacao_CAT_categoria_tra_id_categoria",
                table: "TRA_transacao",
                column: "tra_id_categoria",
                principalTable: "CAT_categoria",
                principalColumn: "cat_id_categoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TRA_transacao_CAT_categoria_tra_id_categoria",
                table: "TRA_transacao");

            migrationBuilder.AlterColumn<long>(
                name: "tra_id_categoria",
                table: "TRA_transacao",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TRA_transacao_CAT_categoria_tra_id_categoria",
                table: "TRA_transacao",
                column: "tra_id_categoria",
                principalTable: "CAT_categoria",
                principalColumn: "cat_id_categoria",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
