
namespace EncantosSalao.Dado.Modelos
{
    using System;
    using System.Collections.Generic;

    using EncantosSalao.Dado.Comum.Modelos;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IEntidadeDeletavel
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Papeis = new HashSet<IdentityUserRole<string>>();
            this.Reivindicacoes = new HashSet<IdentityUserClaim<string>>();
            this.Usuarios = new HashSet<IdentityUserLogin<string>>();
            this.Agendamentos = new HashSet<Agendamentos>();
            this.Saloes = new HashSet<Salao>();
        }

        // Audit info
        public DateTime CriadoEm { get; set; }

        public DateTime? ModificadoEm { get; set; }

        // Entidade Deletavel
        public bool EstaExcluido { get; set; }

        public DateTime? ExcluidoEm { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Papeis { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Reivindicacoes { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Usuarios { get; set; }

        public virtual ICollection<Agendamentos> Agendamentos { get; set; }

        public virtual ICollection<Salao> Saloes { get; set; }
    }
}
