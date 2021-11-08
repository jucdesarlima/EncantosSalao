namespace EncantosSalao.Web.VisaoModelos.Agendamentos
{
    using System.ComponentModel.DataAnnotations;

    using EncantosSalao.Comum;
    using EncantosSalao.Web.ViewModels.Common.CustomValidationAttributes;

    public class AgendamentoEntradaModelo
    {
        [Required]
        public string IdSalao { get; set; }

        [Required]
        public int IdServico { get; set; }

        [Required]
        [AtributoValidaDataTexto(ErrorMessage = ConstantesGlobais.MensagensErro.DataHora)]
        public string Data { get; set; }

        [Required]
        [AtributoValidacaoHoraTexto(ErrorMessage = ConstantesGlobais.MensagensErro.DataHora)]
        public string Hora { get; set; }
    }
}
