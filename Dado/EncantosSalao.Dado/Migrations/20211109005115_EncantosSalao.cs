using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EncantosSalao.Dado.Migrations
{
    public partial class EncantosSalao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: true),
                    EstaExcluido = table.Column<bool>(nullable: false),
                    ExcluidoEm = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: true),
                    EstaExcluido = table.Column<bool>(nullable: false),
                    ExcluidoEm = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                    UrlImagem = table.Column<string>(nullable: false)
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
                    Nome = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                });

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
                    UrlImagem = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticiasBlog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    CategoriaId = table.Column<int>(nullable: true),
                    Descricao = table.Column<string>(maxLength: 700, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
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
                    IdProprietario = table.Column<string>(nullable: true),
                    ProprietarioId = table.Column<string>(nullable: true),
                    IdCategoria = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: true),
                    IdCidade = table.Column<int>(nullable: false),
                    CidadeId = table.Column<int>(nullable: true),
                    Endereco = table.Column<string>(maxLength: 100, nullable: false),
                    Avaliacao = table.Column<double>(nullable: false),
                    ContarAvaliadores = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saloes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Saloes_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Saloes_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Saloes_AspNetUsers_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "AspNetUsers",
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
                    SalaoId = table.Column<string>(nullable: true),
                    ServicoId = table.Column<int>(nullable: true),
                    Disponivel = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicosSalao", x => new { x.IdSalao, x.IdServico });
                    table.ForeignKey(
                        name: "FK_ServicosSalao_Saloes_SalaoId",
                        column: x => x.SalaoId,
                        principalTable: "Saloes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServicosSalao_Servicos_ServicoId",
                        column: x => x.ServicoId,
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
                    EstaExcluido = table.Column<bool>(nullable: false),
                    ExcluidoEm = table.Column<DateTime>(nullable: true),
                    DataHora = table.Column<DateTime>(nullable: false),
                    IdUsuario = table.Column<string>(nullable: false),
                    IdSalao = table.Column<string>(nullable: false),
                    IdServico = table.Column<int>(nullable: false),
                    Confirmado = table.Column<bool>(nullable: true),
                    EstaSalaoAvaliadoPeloUsuario = table.Column<bool>(nullable: true)
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
                name: "IX_Agendamentos_IdUsuario",
                table: "Agendamentos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_IdSalao_IdServico",
                table: "Agendamentos",
                columns: new[] { "IdSalao", "IdServico" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_EstaExcluido",
                table: "AspNetRoles",
                column: "EstaExcluido");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EstaExcluido",
                table: "AspNetUsers",
                column: "EstaExcluido");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_EstaExcluido",
                table: "Categorias",
                column: "EstaExcluido");

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_EstaExcluido",
                table: "Cidades",
                column: "EstaExcluido");

            migrationBuilder.CreateIndex(
                name: "IX_NoticiasBlog_EstaExcluido",
                table: "NoticiasBlog",
                column: "EstaExcluido");

            migrationBuilder.CreateIndex(
                name: "IX_Saloes_CategoriaId",
                table: "Saloes",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Saloes_CidadeId",
                table: "Saloes",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Saloes_EstaExcluido",
                table: "Saloes",
                column: "EstaExcluido");

            migrationBuilder.CreateIndex(
                name: "IX_Saloes_ProprietarioId",
                table: "Saloes",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_CategoriaId",
                table: "Servicos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_EstaExcluido",
                table: "Servicos",
                column: "EstaExcluido");

            migrationBuilder.CreateIndex(
                name: "IX_ServicosSalao_EstaExcluido",
                table: "ServicosSalao",
                column: "EstaExcluido");

            migrationBuilder.CreateIndex(
                name: "IX_ServicosSalao_SalaoId",
                table: "ServicosSalao",
                column: "SalaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicosSalao_ServicoId",
                table: "ServicosSalao",
                column: "ServicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "NoticiasBlog");

            migrationBuilder.DropTable(
                name: "ServicosSalao");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Saloes");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
