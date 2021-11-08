namespace EncantosSalao.Dado.Modelos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EncantosSalao.Comum;
    using EncantosSalao.Dado.Comum.Modelos;

    public class Salao : ModeloBaseDeletavel<string>
    {
        public Salao()
        {
            this.Agendamentos = new HashSet<Agendamentos>();
            this.Servicos = new HashSet<ServicoSalao>();
        }

        [Required]
        [MaxLength(ConstantesGlobais.ValidadoresDados.TamanhoMaximoNome)]
        public string Nome { get; set; }

        [Required]
        public string UrlImagem { get; set; }

        // Não requerido! Permite testar / mostrar funcionalidade com dados propagados na área de administração / gerente
        // Por enquanto, Salons podem ser criados apenas no AdminDashboard e todos eles são gerenciados por uma ManagerAccount propagada
        // Isso será usado quando o registro de um salão se tornar uma opção para todos os usuários
        public string IdProprietario { get; set; }

        public virtual ApplicationUser Proprietario { get; set; }

        public int IdCategoria { get; set; }

        public virtual Categoria Categoria { get; set; }

        public int IdCidade { get; set; }

        public virtual Cidade Cidade { get; set; }

        [Required]
        [MaxLength(ConstantesGlobais.ValidadoresDados.TamanhoMaximoEndereco)]
        public string Endereco { get; set; }

        public double Avaliacao { get; set; }

        public int ContarAvaliadores { get; set; }

        public virtual ICollection<ServicoSalao> Servicos { get; set; }

        public virtual ICollection<Agendamentos> Agendamentos { get; set; }
    }
}
