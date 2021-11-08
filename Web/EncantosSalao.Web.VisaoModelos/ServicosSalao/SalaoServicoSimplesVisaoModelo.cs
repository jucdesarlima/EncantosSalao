namespace EncantosSalao.Web.VisaoModelos.SalaoServicos
{
    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Mapeamento;

    public class SalaoServicoSimplesVisaoModelo : IMapFrom<ServicoSalao>
    {
        public string IdSalao { get; set; }

        public int IdServico { get; set; }

        public bool Disponivel { get; set; }
    }
}
