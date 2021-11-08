namespace EncantosSalao.Web.VisaoModelos.Saloes
{
    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Mapeamento;

    public class SalaoServicoVisaoModelo : IMapFrom<ServicoSalao>
    {
        public string IdSalao { get; set; }

        public int IdServico { get; set; }

        public string NomeServico { get; set; }

        public string DescricaoServico { get; set; }

        public bool Disponivel { get; set; }
    }
}
