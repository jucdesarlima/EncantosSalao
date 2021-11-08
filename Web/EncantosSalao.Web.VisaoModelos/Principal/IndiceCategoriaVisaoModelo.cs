namespace EncantosSalao.Web.VisaoModelos.Principal
{
    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Mapeamento;

    public class IndiceCategoriaVisaoModelo : IMapFrom<Categoria>
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string UrlImagem { get; set; }
    }
}
