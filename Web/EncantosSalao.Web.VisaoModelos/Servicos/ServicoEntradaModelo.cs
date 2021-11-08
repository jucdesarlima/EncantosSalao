namespace EncantosSalao.Web.VisaoModelos.Servicos
{
    using System.ComponentModel.DataAnnotations;

    using EncantosSalao.Comum;

    public class ServicoEntradaModelo
    {
        [Required]
        [StringLength(
            ConstantesGlobais.ValidadoresDados.TamanhoMaximoNome,
            ErrorMessage = ConstantesGlobais.MensagensErro.Nome,
            MinimumLength = ConstantesGlobais.ValidadoresDados.TamanhoMinimoNome)]
        public string Nome { get; set; }

        [Required]
        public int IdCategoria { get; set; }

        [Required]
        [StringLength(
            ConstantesGlobais.ValidadoresDados.TamanhoMaximoDescricao,
            ErrorMessage = ConstantesGlobais.MensagensErro.Descricao,
            MinimumLength = ConstantesGlobais.ValidadoresDados.TamanhoMinimoDescricao)]
        public string Descricao { get; set; }
    }
}
