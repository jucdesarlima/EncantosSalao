namespace EncantosSalao.Web.VisaoModelos.Categorias
{
    using System.ComponentModel.DataAnnotations;

    using EncantosSalao.Comum;
    using EncantosSalao.Web.VisaoModelos.Comum.AtributosValidacaoCustomizados;
    using Microsoft.AspNetCore.Http;

    public class CategoriaEntradaModelo
    {
        [Required]
        [StringLength(
            ConstantesGlobais.ValidadoresDados.TamanhoMaximoNome,
            ErrorMessage = ConstantesGlobais.MensagensErro.Nome,
            MinimumLength = ConstantesGlobais.ValidadoresDados.TamanhoMinimoNome)]
        public string Nome { get; set; }

        [Required]
        [StringLength(
            ConstantesGlobais.ValidadoresDados.TamanhoMaximoDescricao,
            ErrorMessage = ConstantesGlobais.MensagensErro.Descricao,
            MinimumLength = ConstantesGlobais.ValidadoresDados.TamanhoMinimoDescricao)]
        public string Descricao { get; set; }

        [DataType(DataType.Upload)]
        [ValidateImageFile(ErrorMessage = ConstantesGlobais.MensagensErro.Imagem)]
        public IFormFile Imagem { get; set; }
    }
}
