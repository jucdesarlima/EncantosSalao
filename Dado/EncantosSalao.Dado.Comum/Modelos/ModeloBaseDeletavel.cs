namespace EncantosSalao.Dado.Comum.Modelos
{
    using System;

    public abstract class ModeloBaseDeletavel<TKey> : ModeloBase<TKey>, IEntidadeDeletavel
    {
        public bool EstaExcluido { get; set; }

        public DateTime? ExcluidoEm { get; set; }
    }
}
