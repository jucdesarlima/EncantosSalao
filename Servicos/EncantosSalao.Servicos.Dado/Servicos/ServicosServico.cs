namespace EncantosSalao.Servicos.Dado.Servicos
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EncantosSalao.Dado.Comum.Repositorios;
    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Mapeamento;
    using Microsoft.EntityFrameworkCore;

    public class ServicosServico : IServicosServico
    {
        private readonly IRepositorioEntidadeDeletavel<Servico> repositorioServicos;

        public ServicosServico(IRepositorioEntidadeDeletavel<Servico> repositorioServicos)
        {
            this.repositorioServicos = repositorioServicos;
        }

        public async Task<IEnumerable<T>> PegaTodosAsync<T>()
        {
            var services =
                await this.repositorioServicos
                .All()
                .OrderBy(x => x.IdCategoria)
                .ThenBy(x => x.Id)
                .To<T>().ToListAsync();
            return services;
        }

        public async Task<IEnumerable<int>> PegaTodosIdsPorCategoriaAsync(int idCategoria)
        {
            ICollection<int> idsServicos =
                await this.repositorioServicos
                .All()
                .Where(x => x.IdCategoria == idCategoria)
                .OrderBy(x => x.Id)
                .Select(x => x.Id)
                .ToListAsync();
            return idsServicos;
        }

        public async Task<int> AdicionaAsync(string nome, int idCategoria, string descricao)
        {
            var servico = new Servico
            {
                Nome = nome,
                IdCategoria = idCategoria,
                Descricao = descricao,
            };
            await this.repositorioServicos.AddAsync(servico);
            await this.repositorioServicos.SaveChangesAsync();
            return servico.Id;
        }

        public async Task ExcluiAsync(int id)
        {
            var servico =
                await this.repositorioServicos
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.repositorioServicos.Delete(servico);
            await this.repositorioServicos.SaveChangesAsync();
        }
    }
}
