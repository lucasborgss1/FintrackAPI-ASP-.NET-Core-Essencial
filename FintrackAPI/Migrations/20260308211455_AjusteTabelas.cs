using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FintrackAPI.Migrations
{
    /// <inheritdoc />
    public partial class AjusteTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Categorias_CategoriaId",
                table: "Transacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_TipoTransacoes_TipoTransacaoId",
                table: "Transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transacoes",
                table: "Transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoTransacoes",
                table: "TipoTransacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.RenameTable(
                name: "Transacoes",
                newName: "TRA_transacao");

            migrationBuilder.RenameTable(
                name: "TipoTransacoes",
                newName: "TPT_tipo_transacao");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "CAT_categoria");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "TRA_transacao",
                newName: "tra_vl_valor");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "TRA_transacao",
                newName: "tra_nm_titulo");

            migrationBuilder.RenameColumn(
                name: "TipoTransacaoId",
                table: "TRA_transacao",
                newName: "tra_id_tipo_transacao");

            migrationBuilder.RenameColumn(
                name: "IsRecorrente",
                table: "TRA_transacao",
                newName: "tra_fl_recorrente");

            migrationBuilder.RenameColumn(
                name: "IsCredito",
                table: "TRA_transacao",
                newName: "tra_fl_credito");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "TRA_transacao",
                newName: "tra_dt_data");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "TRA_transacao",
                newName: "tra_id_categoria");

            migrationBuilder.RenameColumn(
                name: "TransacaoId",
                table: "TRA_transacao",
                newName: "tra_id_transacao");

            migrationBuilder.RenameIndex(
                name: "IX_Transacoes_TipoTransacaoId",
                table: "TRA_transacao",
                newName: "IX_TRA_transacao_tra_id_tipo_transacao");

            migrationBuilder.RenameIndex(
                name: "IX_Transacoes_CategoriaId",
                table: "TRA_transacao",
                newName: "IX_TRA_transacao_tra_id_categoria");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "TPT_tipo_transacao",
                newName: "tpt_nm_nome");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "TPT_tipo_transacao",
                newName: "tpt_ds_descricao");

            migrationBuilder.RenameColumn(
                name: "TipoTransacaoId",
                table: "TPT_tipo_transacao",
                newName: "tpt_id_tipo_transacao");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "CAT_categoria",
                newName: "cat_nm_nome");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "CAT_categoria",
                newName: "cat_ds_descricao");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "CAT_categoria",
                newName: "cat_id_categoria");

            migrationBuilder.AlterColumn<decimal>(
                name: "tra_vl_valor",
                table: "TRA_transacao",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.UpdateData(
                table: "TRA_transacao",
                keyColumn: "tra_nm_titulo",
                keyValue: null,
                column: "tra_nm_titulo",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tra_nm_titulo",
                table: "TRA_transacao",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "TPT_tipo_transacao",
                keyColumn: "tpt_nm_nome",
                keyValue: null,
                column: "tpt_nm_nome",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tpt_nm_nome",
                table: "TPT_tipo_transacao",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "tpt_ds_descricao",
                table: "TPT_tipo_transacao",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "CAT_categoria",
                keyColumn: "cat_nm_nome",
                keyValue: null,
                column: "cat_nm_nome",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "cat_nm_nome",
                table: "CAT_categoria",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "cat_ds_descricao",
                table: "CAT_categoria",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TRA_transacao",
                table: "TRA_transacao",
                column: "tra_id_transacao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TPT_tipo_transacao",
                table: "TPT_tipo_transacao",
                column: "tpt_id_tipo_transacao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CAT_categoria",
                table: "CAT_categoria",
                column: "cat_id_categoria");

            migrationBuilder.AddForeignKey(
                name: "FK_TRA_transacao_CAT_categoria_tra_id_categoria",
                table: "TRA_transacao",
                column: "tra_id_categoria",
                principalTable: "CAT_categoria",
                principalColumn: "cat_id_categoria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TRA_transacao_TPT_tipo_transacao_tra_id_tipo_transacao",
                table: "TRA_transacao",
                column: "tra_id_tipo_transacao",
                principalTable: "TPT_tipo_transacao",
                principalColumn: "tpt_id_tipo_transacao",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.Sql("ALTER TABLE CAT_categoria AUTO_INCREMENT = 1000000001;");
            migrationBuilder.Sql("ALTER TABLE TPT_tipo_transacao AUTO_INCREMENT = 1000000001;");
            migrationBuilder.Sql("ALTER TABLE TRA_transacao AUTO_INCREMENT = 1000000001;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TRA_transacao_CAT_categoria_tra_id_categoria",
                table: "TRA_transacao");

            migrationBuilder.DropForeignKey(
                name: "FK_TRA_transacao_TPT_tipo_transacao_tra_id_tipo_transacao",
                table: "TRA_transacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TRA_transacao",
                table: "TRA_transacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TPT_tipo_transacao",
                table: "TPT_tipo_transacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CAT_categoria",
                table: "CAT_categoria");

            migrationBuilder.RenameTable(
                name: "TRA_transacao",
                newName: "Transacoes");

            migrationBuilder.RenameTable(
                name: "TPT_tipo_transacao",
                newName: "TipoTransacoes");

            migrationBuilder.RenameTable(
                name: "CAT_categoria",
                newName: "Categorias");

            migrationBuilder.RenameColumn(
                name: "tra_vl_valor",
                table: "Transacoes",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "tra_nm_titulo",
                table: "Transacoes",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "tra_id_tipo_transacao",
                table: "Transacoes",
                newName: "TipoTransacaoId");

            migrationBuilder.RenameColumn(
                name: "tra_id_categoria",
                table: "Transacoes",
                newName: "CategoriaId");

            migrationBuilder.RenameColumn(
                name: "tra_fl_recorrente",
                table: "Transacoes",
                newName: "IsRecorrente");

            migrationBuilder.RenameColumn(
                name: "tra_fl_credito",
                table: "Transacoes",
                newName: "IsCredito");

            migrationBuilder.RenameColumn(
                name: "tra_dt_data",
                table: "Transacoes",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "tra_id_transacao",
                table: "Transacoes",
                newName: "TransacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_TRA_transacao_tra_id_tipo_transacao",
                table: "Transacoes",
                newName: "IX_Transacoes_TipoTransacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_TRA_transacao_tra_id_categoria",
                table: "Transacoes",
                newName: "IX_Transacoes_CategoriaId");

            migrationBuilder.RenameColumn(
                name: "tpt_nm_nome",
                table: "TipoTransacoes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "tpt_ds_descricao",
                table: "TipoTransacoes",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "tpt_id_tipo_transacao",
                table: "TipoTransacoes",
                newName: "TipoTransacaoId");

            migrationBuilder.RenameColumn(
                name: "cat_nm_nome",
                table: "Categorias",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "cat_ds_descricao",
                table: "Categorias",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "cat_id_categoria",
                table: "Categorias",
                newName: "CategoriaId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Transacoes",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Transacoes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TipoTransacoes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TipoTransacoes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Categorias",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Categorias",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transacoes",
                table: "Transacoes",
                column: "TransacaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoTransacoes",
                table: "TipoTransacoes",
                column: "TipoTransacaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Categorias_CategoriaId",
                table: "Transacoes",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_TipoTransacoes_TipoTransacaoId",
                table: "Transacoes",
                column: "TipoTransacaoId",
                principalTable: "TipoTransacoes",
                principalColumn: "TipoTransacaoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
