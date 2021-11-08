namespace EncantosSalao.Dado.Migracoes
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddAllEntitiesAgainWithLengthConstraintsForColumnsAndStringIdsForSalonsAndAppointments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoticiasBlog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: true),
                    EstaExcluido = table.Column<bool>(nullable: false),
                    ExcluidoEm = table.Column<DateTime>(nullable: true),
                    Titulo = table.Column<string>(maxLength: 60, nullable: false),
                    Conteudo = table.Column<string>(maxLength: 3500, nullable: false),
                    Autor = table.Column<string>(maxLength: 40, nullable: false),
                    UrlImagem = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticiasBlog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: true),
                    EstaExcluido = table.Column<bool>(nullable: false),
                    ExcluidoEm = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 40, nullable: false),
                    Descricao = table.Column<string>(maxLength: 700, nullable: false),
                    UrlImagem = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: true),
                    EstaExcluido = table.Column<bool>(nullable: false),
                    ExcluidoEm = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 40, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: true),
                    EstaExcluido = table.Column<bool>(nullable: false),
                    ExcluidoEm = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 40, nullable: false),
                    IdCategoria = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 700, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicos_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Saloes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: true),
                    EstaExcluido = table.Column<bool>(nullable: false),
                    ExcluidoEm = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 40, nullable: false),
                    UrlImagem = table.Column<string>(nullable: false),
                    IdCategoria = table.Column<int>(nullable: false),
                    IdCidade = table.Column<int>(nullable: false),
                    Endereco = table.Column<string>(maxLength: 100, nullable: false),
                    Avaliacao = table.Column<double>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saloes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Saloes_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Saloes_Cidades_IdCidade",
                        column: x => x.IdCidade,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServicosSalao",
                columns: table => new
                {
                    IdSalao = table.Column<string>(nullable: false),
                    IdServico = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: true),
                    EstaExcluido = table.Column<bool>(nullable: false),
                    ExcluidoEm = table.Column<DateTime>(nullable: true),
                    Disponivel = table.Column<bool>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicosSalao", x => new { x.IdSalao, x.IdServico });
                    table.ForeignKey(
                        name: "FK_ServicosSalao_Saloes_IdSalao",
                        column: x => x.IdSalao,
                        principalTable: "Saloes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServicosSalao_Servicos_IdServico",
                        column: x => x.IdServico,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: true),
                    EstaEcluido = table.Column<bool>(nullable: false),
                    ExcluidoEm = table.Column<DateTime>(nullable: true),
                    DataHora = table.Column<DateTime>(nullable: false),
                    IdUsuario = table.Column<string>(nullable: false),
                    IdSalao = table.Column<string>(nullable: false),
                    IdServico = table.Column<int>(nullable: false),
                    Confirmado = table.Column<bool>(nullable: true),
                    EstaSalaoAvaliadoPeloUsuario = table.Column<bool>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Saloes_IdSalao",
                        column: x => x.IdSalao,
                        principalTable: "Saloes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Servicos_IdServico",
                        column: x => x.IdServico,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendamentos_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendamentos_ServicosSalao_IdSalao_IdServico",
                        columns: x => new { x.IdSalao, x.IdServico },
                        principalTable: "ServicosSalao",
                        principalColumns: new[] { "IdSalao", "IdServico" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_EstaExcluido",
                table: "Agendamentos",
                column: "EstaExcluido");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_IdServico",
                table: "Agendamentos",
                column: "IdServico");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_IdsUsuario",
                table: "Agendamentos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_IdSalao_IdServico",
                table: "Agendamentos",
                columns: new[] { "IdSalao", "IdServico" });

            migrationBuilder.CreateIndex(
                name: "IX_NoticiasBlog_EstaExcluido",
                table: "NoticiasBlog",
                column: "EstaExcluido");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_EstaExcluido",
                table: "Categorias",
                column: "EstaExcluido");

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_EstaExcluido",
                table: "Cidades",
                column: "EstaExcluido");

            migrationBuilder.CreateIndex(
                name: "IX_Saloes_IdCategoria",
                table: "Saloes",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Saloes_IdCidade",
                table: "Saloes",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_Saloes_EstaExcluido",
                table: "Saloes",
                column: "EstaExcluido");

            migrationBuilder.CreateIndex(
                name: "IX_ServicosSalao_EstaExcluido",
                table: "ServicosSalao",
                column: "EstaExcluido");

            migrationBuilder.CreateIndex(
                name: "IX_ServicosSalao_IdServico",
                table: "ServicosSalao",
                column: "IdServico");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_IdCategoria",
                table: "Servicos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_EstaExcluido",
                table: "Servicos",
                column: "IsExcluido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "NoticiasBlog");

            migrationBuilder.DropTable(
                name: "ServicosSalao");

            migrationBuilder.DropTable(
                name: "Saloes");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
