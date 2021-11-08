namespace EncantosSalao.Web.VisaoModelos.NoticiasBlog
{
    using System.ComponentModel.DataAnnotations;

    using EncantosSalao.Comum;
    using EncantosSalao.Web.VisaoModelos.Comum.AtributosValidacaoCustomizados;
    using Microsoft.AspNetCore.Http;

    public class NoticiasBlogEntradaModelo
    {
        [Required]
        [StringLength(
            ConstantesGlobais.ValidadoresDados.TamanhoMaximoTitulo,
            ErrorMessage = ConstantesGlobais.MensagensErro.Titulo,
            MinimumLength = ConstantesGlobais.ValidadoresDados.TamanhoMinimoTitulo)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(
            ConstantesGlobais.ValidadoresDados.TamanhoMaximoConteudo,
            ErrorMessage = ConstantesGlobais.MensagensErro.Conteudo,
            MinimumLength = ConstantesGlobais.ValidadoresDados.TamanhoMinimoConteudo)]
        public string Conteudo { get; set; }

        [Required]
        [StringLength(
            ConstantesGlobais.ValidadoresDados.TamanhoMaximoNome,
            ErrorMessage = ConstantesGlobais.MensagensErro.Autor,
            MinimumLength = ConstantesGlobais.ValidadoresDados.TamanhoMinimoNome)]
        public string Autor { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        [ValidateImageFile(ErrorMessage = ConstantesGlobais.MensagensErro.Imagem)]
        public IFormFile Imagem { get; set; }
    }
}
