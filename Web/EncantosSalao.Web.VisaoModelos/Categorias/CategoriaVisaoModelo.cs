namespace EncantosSalao.Web.VisaoModelos.Categorias
{
    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Mapeamento;

    public class CategoriaVisaoModelo : IMapFrom<Categoria>
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string UrlImagem { get; set; }

        public int ContagemSaloes { get; set; }

        public int ContagemServicos { get; set; }
    }
}
