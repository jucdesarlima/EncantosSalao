namespace EncantosSalao.Web.VisaoModelos.Saloes
{
    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Mapeamento;

    public class SalaoVisaoModelo : IMapFrom<Salao>
    {
        public string Id { get; set; }

        public string Nome { get; set; }

        public string UrlImagem { get; set; }

        public int IdCategoria { get; set; }

        public string NomeCategoria { get; set; }

        public string NomeCidade { get; set; }

        public string Endereco { get; set; }

        public double Avaliacao { get; set; }

        public int ContadorAvaliadores { get; set; }

        public int ContadorAgendamntos { get; set; }
    }
}
