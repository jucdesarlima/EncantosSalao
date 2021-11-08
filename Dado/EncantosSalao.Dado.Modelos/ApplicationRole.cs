
namespace EncantosSalao.Dado.Modelos
{
    using System;

    using EncantosSalao.Dado.Comum.Modelos;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationRole : IdentityRole, IAuditInfo, IEntidadeDeletavel
    {
        public ApplicationRole()
            : this(null)
        {
        }

        public ApplicationRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public DateTime CriadoEm { get; set; }

        public DateTime? ModificadoEm { get; set; }

        public bool EstaExcluido { get; set; }

        public DateTime? ExcluidoEm { get; set; }
    }
}
