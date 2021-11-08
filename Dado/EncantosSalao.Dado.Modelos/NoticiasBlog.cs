namespace EncantosSalao.Dado.Modelos
{
    using System.ComponentModel.DataAnnotations;

    using EncantosSalao.Comum;
    using EncantosSalao.Dado.Comum.Modelos;

    public class NoticiasBlog : ModeloBaseDeletavel<int>
    {
        [Required]
        [MaxLength(ConstantesGlobais.ValidadoresDados.TamanhoMaximoTitulo)]
        public string Titulo { get; set; }

        [Required]
        [MaxLength(ConstantesGlobais.ValidadoresDados.TamanhoMaximoConteudo)]
        public string Conteudo { get; set; }

        // O NoticiasBlog só pode ser criado no painel de controle do administrador
        // então o autor não é um usuário, apenas uma string para o nome
        [Required]
        [MaxLength(ConstantesGlobais.ValidadoresDados.TamanhoMaximoNome)]
        public string Autor { get; set; }

        [Required]
        public string UrlImagem { get; set; }
    }
}
