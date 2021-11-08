namespace EncantosSalao.Web.VisaoModelos.Servicos
{
    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Mapeamento;

    public class ServicoVisaoModelo : IMapFrom<Servico>
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string NomeCategoria { get; set; }

        public int ContadorSaloes { get; set; }

        public int ContadorAgendamentos { get; set; }
    }
}
