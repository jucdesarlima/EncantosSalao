namespace EncantosSalao.Web.VisaoModelos.Saloes
{
    using System.ComponentModel.DataAnnotations;

    using EncantosSalao.Comum;
    using EncantosSalao.Web.VisaoModelos.Comum.AtributosValidacaoCustomizados;
    using Microsoft.AspNetCore.Http;

    public class SalaoEntradaModelo
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
        public int IdCidade { get; set; }

        [Required]
        [StringLength(
            ConstantesGlobais.ValidadoresDados.TamanhoMaximoEndereco,
            ErrorMessage = ConstantesGlobais.MensagensErro.Endereco,
            MinimumLength = ConstantesGlobais.ValidadoresDados.TamanhoMinimoEndereco)]
        public string Endereco { get; set; }

        [DataType(DataType.Upload)]
        [ValidateImageFile(ErrorMessage = ConstantesGlobais.MensagensErro.Imagem)]
        public IFormFile Imagem { get; set; }
    }
}
