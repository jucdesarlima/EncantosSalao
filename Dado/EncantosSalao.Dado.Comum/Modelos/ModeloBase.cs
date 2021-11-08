namespace EncantosSalao.Dado.Comum.Modelos
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class ModeloBase<TKey> : IAuditInfo
    {
        [Key]
        public TKey Id { get; set; }

        public DateTime CriadoEm { get; set; }

        public DateTime? ModificadoEm { get; set; }
    }
}
