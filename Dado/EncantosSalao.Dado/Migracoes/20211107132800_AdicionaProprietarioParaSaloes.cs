namespace EncantosSalao.Dado.Migracoes
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddOwnerToSalons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdProprietario",
                table: "Saloes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Saloes_IdProprietario",
                table: "Saloes",
                column: "IdProprietario");

            migrationBuilder.AddForeignKey(
                name: "FK_Saloes_AspNetUsers_IdProprietario",
                table: "Saloes",
                column: "IdProprietario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saloes_AspNetUsers_IdProprietario",
                table: "Saloes");

            migrationBuilder.DropIndex(
                name: "IX_Saloes_IdProprietario",
                table: "Saloes");

            migrationBuilder.DropColumn(
                name: "IdProprietario",
                table: "Saloes");
        }
    }
}
