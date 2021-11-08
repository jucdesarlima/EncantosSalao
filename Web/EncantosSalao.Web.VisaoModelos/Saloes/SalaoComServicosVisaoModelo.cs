namespace EncantosSalao.Web.VisaoModelos.Saloes
{
    using System.Collections.Generic;

    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Mapeamento;

    public class SalaoComServicosVisaoModelo : IMapFrom<Salao>
    {
        public string Id { get; set; }

        public string Nome { get; set; }

        public string UrlImagem { get; set; }

        public string NomeCategoria { get; set; }

        public string NomeCidade { get; set; }

        public string Endereco { get; set; }

        public double Avaliacao { get; set; }

        public int ContadorAvaliadores { get; set; }

        public virtual ICollection<SalaoServicoVisaoModelo> Servicos { get; set; }
    }
}
