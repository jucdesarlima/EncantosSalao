namespace EncantosSalao.Dado.Modelos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EncantosSalao.Comum;
    using EncantosSalao.Dado.Comum.Modelos;

    public class Categoria : ModeloBaseDeletavel<int>
    {
        public Categoria()
        {
            this.Servicos = new HashSet<Servico>();
            this.Saloes = new HashSet<Salao>();
        }

        [Required]
        [MaxLength(ConstantesGlobais.ValidadoresDados.TamanhoMaximoNome)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(ConstantesGlobais.ValidadoresDados.TamanhoMaximoDescricao)]
        public string Descricao { get; set; }

        [Required]
        public string UrlImagem { get; set; }

        public virtual ICollection<Servico> Servicos { get; set; }

        public virtual ICollection<Salao> Saloes { get; set; }
    }
}
