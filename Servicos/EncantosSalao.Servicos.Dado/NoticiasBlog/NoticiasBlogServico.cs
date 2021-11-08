namespace EncantosSalao.Servicos.Dado.NoticiasBlog
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EncantosSalao.Dado.Comum.Repositorios;
    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Mapeamento;
    using EncantosSalao.Web.VisaoModelos.NoticiasBlog;
    using Microsoft.EntityFrameworkCore;

    public class NoticiasBlogServico : INoticiasBlogServico
    {
        private readonly IRepositorioEntidadeDeletavel<NoticiasBlog> repositorioNoticiasBlog;

        public NoticiasBlogServico(IRepositorioEntidadeDeletavel<NoticiasBlog> repositorioNoticiasBlog)
        {
            this.repositorioNoticiasBlog = repositorioNoticiasBlog;
        }

        public async Task<IEnumerable<T>> PegaTodosAsync<T>(int? count = null)
        {
            IQueryable<NoticiasBlog> query =
                this.repositorioNoticiasBlog
                .All()
                .OrderByDescending(x => x.CriadoEm);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return await query.To<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> PegaTodosComPaginacaoAsync<T>(
            int? sortId,
            int pageSize,
            int pageIndex)
        {
            IQueryable<NoticiasBlog> query =
                this.repositorioNoticiasBlog
                .AllAsNoTracking()
                .OrderByDescending(x => x.CriadoEm);

            if (sortId != null)
            {
                query = query
                    .Where(x => x.Id == sortId);
            }

            return await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize).To<T>().ToListAsync();
        }

        public async Task<int> PegaContadorPorPaginacaoAsync()
        {
            return await this.repositorioNoticiasBlog
                .AllAsNoTracking()
                .CountAsync();

            // return await query.CountAsync();
        }

        public async Task<T> PegaPorIdAsync<T>(int id)
        {
            var noticiasBlog =
                await this.repositorioNoticiasBlog
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return noticiasBlog;
        }

        public async Task AdicionaAsync(string titulo, string conteudo, string autor, string urlImagem)
        {
            await this.repositorioNoticiasBlog.AddAsync(new NoticiasBlog
            {
                Titulo = titulo,
                Conteudo = conteudo,
                Autor = autor,
                UrlImagem = urlImagem,
            });
            await this.repositorioNoticiasBlog.SaveChangesAsync();
        }

        public async Task ExcluiAsync(int id)
        {
            var noticiasBlog =
                await this.repositorioNoticiasBlog
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.repositorioNoticiasBlog.Delete(noticiasBlog);
            await this.repositorioNoticiasBlog.SaveChangesAsync();
        }
    }
}
