namespace EncantosSalao.Web.VisaoModelos.SalaoServicos
{
    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Mapeamento;

    public class SalaoServicoDetalhesVisaoModelo : IMapFrom<ServicoSalao>
    {
        public string IdSalao { get; set; }

        public string NomeSalao { get; set; }

        public string NomeCidadeSalao { get; set; }

        public string EnderecoSalao { get; set; }

        public int IdServico { get; set; }

        public string NomeServico { get; set; }
    }
}
