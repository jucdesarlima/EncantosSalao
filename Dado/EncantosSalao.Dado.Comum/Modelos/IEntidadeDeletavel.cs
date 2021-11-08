namespace EncantosSalao.Dado.Comum.Modelos
{
    using System;

    public interface IEntidadeDeletavel
    {
        bool EstaExcluido { get; set; }

        DateTime? ExcluidoEm { get; set; }
    }
}
