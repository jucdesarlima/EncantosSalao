namespace EncantosSalao.Dado.Modelos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EncantosSalao.Dado.Comum.Modelos;

    public class ServicoSalao : ModeloBaseDeletavel<int>
    {
        public ServicoSalao()
        {
            this.Agendamentos = new HashSet<Agendamentos>();
        }

        [Required]
        public string IdSalao { get; set; }

        public virtual Salao Salao { get; set; }

        public int IdServico { get; set; }

        public virtual Servico Servico { get; set; }

        // Cada Salao pega todos os servicos a partir de sua Categoria, mas ela pode nao fornecer todos
        public bool Disponivel { get; set; }

        public virtual ICollection<Agendamentos> Agendamentos { get; set; }
    }
}
