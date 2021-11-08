namespace EncantosSalao.Web.VisaoModelos.Categorias
{
    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Mapeamento;

    public class CategoriaSimplesVisaoModelo : IMapFrom<Categoria>
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int ContadorSaloes { get; set; }
    }
}
