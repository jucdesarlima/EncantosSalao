namespace EncantosSalao.Dado
{
    using System;
    using System.Threading.Tasks;

    using EncantosSalao.Dado.Comum;

    using Microsoft.EntityFrameworkCore;

    public class DbExecutorConsulta : IDbExecutorConsulta
    {
        public DbExecutorConsulta(ApplicationDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ApplicationDbContext Context { get; set; }

        public Task RunQueryAsync(string query, params object[] parameters)
        {
            return this.Context.Database.ExecuteSqlRawAsync(query, parameters);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Context?.Dispose();
            }
        }
    }
}
