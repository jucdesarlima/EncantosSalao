namespace EncantosSalao.Web.VisaoModelos.Comum.ListasSelecionadas
{
    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Mapeamento;

    public class CidadeSelecionadaListaVisaoModelo : IMapFrom<Cidade>
    {
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}
