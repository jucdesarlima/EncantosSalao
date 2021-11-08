namespace EncantosSalao.Web.VisaoModelos.Agendamentos
{
    using System.ComponentModel.DataAnnotations;

    using EncantosSalao.Comum;
    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Mapeamento;

    public class AgendamentoAvaliacaoVisaoModelo : IMapFrom<Agendamentos>
    {
        public string Id { get; set; }

        public string IdSalao { get; set; }

        public string NomeSalao { get; set; }

        public string NomeCategoriaSalao { get; set; }

        public string NomeCidadeSalao { get; set; }

        public string EnderecoSalao { get; set; }

        public string UrlImagemSalao { get; set; }

        public bool? EstaSalaoAvaliadoPeloUsuario { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = ConstantesGlobais.MensagensErro.Avaliacao)]
        public int ValorAvaliado { get; set; }
    }
}
