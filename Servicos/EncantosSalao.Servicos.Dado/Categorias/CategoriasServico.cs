namespace EncantosSalao.Servicos.Dado.Categorias
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EncantosSalao.Dado.Comum.Repositorios;
    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Mapeamento;
    using Microsoft.EntityFrameworkCore;

    public class CategoriasServico : ICategoriasServico
    {
        private readonly IRepositorioEntidadeDeletavel<Categoria> repositorioCategorias;

        public CategoriasServico(IRepositorioEntidadeDeletavel<Categoria> repositorioCategorias)
        {
            this.repositorioCategorias = repositorioCategorias;
        }

        public async Task<IEnumerable<T>> PegaTodosAsync<T>(int? count = null)
        {
            IQueryable<Categoria> query =
                this.repositorioCategorias
                .All()
                .OrderBy(x => x.Id);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return await query.To<T>().ToListAsync();
        }

        public async Task<T> PegaPorIdAsync<T>(int id)
        {
            var category =
                await this.repositorioCategorias
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return category;
        }

        public async Task AdicionaAsync(string nome, string descricao, string urlImagem)
        {
            await this.repositorioCategorias.AddAsync(new Categoria
            {
                Nome = nome,
                Descricao = descricao,
                UrlImagem = urlImagem,
            });
            await this.repositorioCategorias.SaveChangesAsync();
        }

        public async Task ExcluiAsync(int id)
        {
            var categoria =
                await this.repositorioCategorias
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.repositorioCategorias.Delete(categoria);
            await this.repositorioCategorias.SaveChangesAsync();
        }
    }
}
