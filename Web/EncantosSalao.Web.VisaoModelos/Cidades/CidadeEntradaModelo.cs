namespace EncantosSalao.Web.VisaoModelos.Cidades
{
    using System.ComponentModel.DataAnnotations;

    using EncantosSalao.Comum;

    public class CidadeEntradaModelo
    {
        [Required]
        [StringLength(
            ConstantesGlobais.ValidadoresDados.TamanhoMaximoNome,
            ErrorMessage = ConstantesGlobais.MensagensErro.Nome,
            MinimumLength = ConstantesGlobais.ValidadoresDados.TamanhoMinimoNome)]
        public string Nome { get; set; }
    }
}
