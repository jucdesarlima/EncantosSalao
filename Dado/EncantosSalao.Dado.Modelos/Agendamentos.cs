namespace EncantosSalao.Dado.Modelos
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EncantosSalao.Dado.Comum.Modelos;

    public class Agendamentos : ModeloBaseDeletavel<string>
    {
        public DateTime DataHora { get; set; }

        [Required]
        public string IdUsuario { get; set; }

        public virtual ApplicationUser Usuario { get; set; }

        [Required]
        public string IdSalao { get; set; }

        public virtual Salao Salao { get; set; }

        public int IdServico { get; set; }

        public virtual Servico Servico { get; set; }

        public virtual ServicoSalao ServicoSalao { get; set; }

        // O salao pode confirmar ou recusar um agendamento
        public bool? Confirmado { get; set; }

        // Para cada compromisso anterior (e confirmado), o usuário pode avaliar o salão de beleza
        // Mas a classificação pode ser dada apenas uma vez para cada consulta
        public bool? EstaSalaoAvaliadoPeloUsuario { get; set; }
    }
}
