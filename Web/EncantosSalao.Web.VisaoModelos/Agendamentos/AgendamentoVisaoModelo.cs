namespace EncantosSalao.Web.VisaoModelos.Agendamentos
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Mapeamento;

    public class AgendamentoVisaoModelo : IMapFrom<Agendamentos>
    {
        public string Id { get; set; }

        public DateTime DataHora { get; set; }

        public string EmailUsuario { get; set; }

        public string IdSalao { get; set; }

        public string NomeSalao { get; set; }

        public string NomeCidadeSalao { get; set; }

        public string EnderecoSalao { get; set; }

        public int IdServico { get; set; }

        public string NomeServico { get; set; }

        public bool? Confirmado { get; set; }

        public bool? EstaSalaoAvaliadoPeloUsuario { get; set; }
    }
}
