namespace EncantosSalao.Dado.Comum.Repositorios
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRepositorio<TEntity> : IDisposable
        where TEntity : class
    {
        IQueryable<TEntity> All();

        IQueryable<TEntity> AllAsNoTracking();

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task<int> SaveChangesAsync();
    }
}
