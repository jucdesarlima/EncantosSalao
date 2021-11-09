namespace EncantosSalao.Web.VisaoModelos.Agendamentos
{
    using System.ComponentModel.DataAnnotations;

    using EncantosSalao.Comum;
    using EncantosSalao.Web.VisaoModelos.Comum.AtributosValidacaoCustomizados;

    public class AgendamentoEntradaModelo
    {
        [Required]
        public string IdSalao { get; set; }

        [Required]
        public int IdServico { get; set; }

        [Required]
        [ValidateDateString(ErrorMessage = ConstantesGlobais.MensagensErro.DataHora)]
        public string Data { get; set; }

        [Required]
        [ValidateTimeString(ErrorMessage = ConstantesGlobais.MensagensErro.DataHora)]
        public string Hora { get; set; }
    }
}
