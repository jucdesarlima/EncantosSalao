namespace EncantosSalao.Dado.Migracoes
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddRaterCountToSalons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContarAvaliadores",
                table: "Saloes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContarAvaliadores",
                table: "Saloes");
        }
    }
}
