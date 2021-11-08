namespace EncantosSalao.Dado.Repositorios
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using EncantosSalao.Dado.Comum.Modelos;
    using EncantosSalao.Dado.Comum.Repositorios;

    using Microsoft.EntityFrameworkCore;

    public class EfRepositorioEntidadeDeletavel<TEntity> : EfRepositorio<TEntity>, IRepositorioEntidadeDeletavel<TEntity>
        where TEntity : class, IEntidadeDeletavel
    {
        public EfRepositorioEntidadeDeletavel(ApplicationDbContext context)
            : base(context)
        {
        }

        public override IQueryable<TEntity> All() => base.All().Where(x => !x.EstaExcluido);

        public override IQueryable<TEntity> AllAsNoTracking() => base.AllAsNoTracking().Where(x => !x.EstaExcluido);

        public IQueryable<TEntity> AllWithDeleted() => base.All().IgnoreQueryFilters();

        public IQueryable<TEntity> AllAsNoTrackingWithDeleted() => base.AllAsNoTracking().IgnoreQueryFilters();

        public Task<TEntity> GetByIdWithDeletedAsync(params object[] id)
        {
            var getByIdPredicate = EfExpressionHelper.BuildByIdPredicate<TEntity>(this.Context, id);
            return this.AllWithDeleted().FirstOrDefaultAsync(getByIdPredicate);
        }

        public void HardDelete(TEntity entity) => base.Delete(entity);

        public void Undelete(TEntity entity)
        {
            entity.EstaExcluido = false;
            entity.ExcluidoEm = null;
            this.Update(entity);
        }

        public override void Delete(TEntity entity)
        {
            entity.EstaExcluido = true;
            entity.ExcluidoEm = DateTime.UtcNow;
            this.Update(entity);
        }
    }
}
