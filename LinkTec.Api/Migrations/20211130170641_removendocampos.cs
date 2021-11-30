using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkTec.Api.Migrations
{
    public partial class removendocampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfertanteCertificados_Parceiros_OfertanteId",
                table: "OfertanteCertificados");

            migrationBuilder.DropIndex(
                name: "IX_OfertanteCertificados_OfertanteId",
                table: "OfertanteCertificados");

            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "OfertanteCertificados");

            migrationBuilder.DropColumn(
                name: "OfertanteId",
                table: "OfertanteCertificados");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Imagem",
                table: "OfertanteCertificados",
                type: "longblob",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OfertanteId",
                table: "OfertanteCertificados",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_OfertanteCertificados_OfertanteId",
                table: "OfertanteCertificados",
                column: "OfertanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfertanteCertificados_Parceiros_OfertanteId",
                table: "OfertanteCertificados",
                column: "OfertanteId",
                principalTable: "Parceiros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
