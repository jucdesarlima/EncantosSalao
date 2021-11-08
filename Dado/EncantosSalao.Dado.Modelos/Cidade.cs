namespace EncantosSalao.Dado.Modelos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EncantosSalao.Comum;
    using EncantosSalao.Dado.Comum.Modelos;

    public class Cidade : ModeloBaseDeletavel<int>
    {
        public Cidade()
        {
            this.Saloes = new HashSet<Salao>();
        }

        [Required]
        [MaxLength(ConstantesGlobais.ValidadoresDados.TamanhoMaximoNome)]
        public string Nome { get; set; }

        public virtual ICollection<Salao> Saloes { get; set; }
    }
}
