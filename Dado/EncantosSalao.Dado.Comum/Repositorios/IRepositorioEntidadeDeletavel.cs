namespace EncantosSalao.Dado.Comum.Repositorios
{
    using System.Linq;
    using System.Threading.Tasks;

    using EncantosSalao.Dado.Comum.Modelos;

    public interface IRepositorioEntidadeDeletavel<TEntity> : IRepositorio<TEntity>
        where TEntity : class, IEntidadeDeletavel
    {
        IQueryable<TEntity> AllWithDeleted();

        IQueryable<TEntity> AllAsNoTrackingWithDeleted();

        Task<TEntity> GetByIdWithDeletedAsync(params object[] id);

        void HardDelete(TEntity entity);

        void Undelete(TEntity entity);
    }
}
