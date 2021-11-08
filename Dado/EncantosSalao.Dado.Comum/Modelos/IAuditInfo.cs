namespace EncantosSalao.Dado.Comum.Modelos
{
    using System;

    public interface IAuditInfo
    {
        DateTime CriadoEm { get; set; }

        DateTime? ModificadoEm { get; set; }
    }
}
