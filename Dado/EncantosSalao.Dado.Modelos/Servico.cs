namespace EncantosSalao.Dado.Modelos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EncantosSalao.Comum;
    using EncantosSalao.Dado.Comum.Modelos;

    public class Servico : ModeloBaseDeletavel<int>
    {
        public Servico()
        {
            this.Saloes = new HashSet<ServicoSalao>();
            this.Agendamentos = new HashSet<Agendamentos>();
        }

        [Required]
        [MaxLength(ConstantesGlobais.ValidadoresDados.TamanhoMaximoNome)]
        public string Nome { get; set; }

        public int IdCategoria { get; set; }

        public virtual Categoria Categoria { get; set; }

        [Required]
        [MaxLength(ConstantesGlobais.ValidadoresDados.TamanhoMaximoDescricao)]
        public string Descricao { get; set; }

        public virtual ICollection<ServicoSalao> Saloes { get; set; }

        public virtual ICollection<Agendamentos> Agendamentos { get; set; }
    }
}
