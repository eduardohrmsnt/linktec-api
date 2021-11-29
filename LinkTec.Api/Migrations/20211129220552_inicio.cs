using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkTec.Api.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContatoCliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mensagem = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatoCliente", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmailsTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TipoEmail = table.Column<int>(type: "int", nullable: false),
                    Assunto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Corpo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailsTemplate", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Parceiros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoDocumento = table.Column<int>(type: "int", nullable: false),
                    Documento = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoParceiro = table.Column<int>(type: "int", nullable: false),
                    FormaPagamento = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parceiros", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OfertanteCertificados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ParceiroId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Imagem = table.Column<byte[]>(type: "longblob", nullable: true),
                    TipoServico = table.Column<int>(type: "int", nullable: false),
                    OfertanteId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertanteCertificados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfertanteCertificados_Parceiros_OfertanteId",
                        column: x => x.OfertanteId,
                        principalTable: "Parceiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfertanteCertificados_Parceiros_ParceiroId",
                        column: x => x.ParceiroId,
                        principalTable: "Parceiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SolicitacoesDeServico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SolicitanteId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OfertanteId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    TipoServico = table.Column<int>(type: "int", nullable: false),
                    Enunciado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescricaoServico = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ativa = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Aceita = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Recusada = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FormaPagamentoAceita = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacoesDeServico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitacoesDeServico_Parceiros_OfertanteId",
                        column: x => x.OfertanteId,
                        principalTable: "Parceiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolicitacoesDeServico_Parceiros_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "Parceiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PropostasSolicitacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SolicitacaoDeServicoId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    SolicitacaoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OfertanteId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ValorHora = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    HoraProposta = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Aceitada = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Recusada = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropostasSolicitacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropostasSolicitacoes_Parceiros_OfertanteId",
                        column: x => x.OfertanteId,
                        principalTable: "Parceiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropostasSolicitacoes_SolicitacoesDeServico_SolicitacaoDeSer~",
                        column: x => x.SolicitacaoDeServicoId,
                        principalTable: "SolicitacoesDeServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_OfertanteCertificados_OfertanteId",
                table: "OfertanteCertificados",
                column: "OfertanteId");

            migrationBuilder.CreateIndex(
                name: "IX_OfertanteCertificados_ParceiroId",
                table: "OfertanteCertificados",
                column: "ParceiroId");

            migrationBuilder.CreateIndex(
                name: "IX_PropostasSolicitacoes_OfertanteId",
                table: "PropostasSolicitacoes",
                column: "OfertanteId");

            migrationBuilder.CreateIndex(
                name: "IX_PropostasSolicitacoes_SolicitacaoDeServicoId",
                table: "PropostasSolicitacoes",
                column: "SolicitacaoDeServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacoesDeServico_OfertanteId",
                table: "SolicitacoesDeServico",
                column: "OfertanteId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacoesDeServico_SolicitanteId",
                table: "SolicitacoesDeServico",
                column: "SolicitanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContatoCliente");

            migrationBuilder.DropTable(
                name: "EmailsTemplate");

            migrationBuilder.DropTable(
                name: "OfertanteCertificados");

            migrationBuilder.DropTable(
                name: "PropostasSolicitacoes");

            migrationBuilder.DropTable(
                name: "SolicitacoesDeServico");

            migrationBuilder.DropTable(
                name: "Parceiros");
        }
    }
}
