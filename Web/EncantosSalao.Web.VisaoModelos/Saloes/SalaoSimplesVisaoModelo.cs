namespace EncantosSalao.Web.VisaoModelos.Saloes
{
    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Mapeamento;

    public class SalaoSimplesVisaoModelo : IMapFrom<Salao>
    {
        public string Id { get; set; }

        public string Nome { get; set; }
    }
}
