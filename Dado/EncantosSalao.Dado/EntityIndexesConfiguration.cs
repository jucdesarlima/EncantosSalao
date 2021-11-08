namespace EncantosSalao.Dado
{
    using System.Linq;

    using EncantosSalao.Dado.Comum.Modelos;

    using Microsoft.EntityFrameworkCore;

    internal static class EntityIndexesConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            // IDeletableEntity.IsDeleted index
            var deletableEntityTypes = modelBuilder.Model
                .GetEntityTypes()
                .Where(et => et.ClrType != null && typeof(IEntidadeDeletavel).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                modelBuilder.Entity(deletableEntityType.ClrType).HasIndex(nameof(IEntidadeDeletavel.EstaExcluido));
            }
        }
    }
}
