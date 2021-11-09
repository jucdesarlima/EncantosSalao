namespace EncantosSalao.Servicos.Dado.Saloes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EncantosSalao.Dado.Comum.Repositorios;
    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Mapeamento;
    using Microsoft.EntityFrameworkCore;

    public class SaloesServico : ISaloesServico
    {
        private readonly IRepositorioEntidadeDeletavel<Salao> repositorioSaloes;

        public SaloesServico(IRepositorioEntidadeDeletavel<Salao> repositorioSaloes)
        {
            this.repositorioSaloes = repositorioSaloes;
        }

        public async Task<IEnumerable<T>> PegaTodosAsync<T>()
        {
            var saloes =
                await this.repositorioSaloes
                .All()
                .OrderBy(x => x.Nome)
                .To<T>().ToListAsync();
            return saloes;
        }

        public async Task<IEnumerable<T>> PegaTodosOrdenandoFiltrandoPaginandoAsync<T>(
            string searchString,
            int? sortId,
            int pageSize,
            int pageIndex)
        {
            IQueryable<Salao> query =
                this.repositorioSaloes
                .AllAsNoTracking()
                .OrderBy(x => x.Nome);

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query
                    .Where(x => x.Nome.ToLower()
                                .Contains(searchString.ToLower()));
            }

            if (sortId != null)
            {
                query = query
                    .Where(x => x.IdCategoria == sortId);
            }

            return await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .To<T>().ToListAsync();
        }

        public async Task<int> PegaContadorPorPaginacaoAsync(string searchString, int? sortId)
        {
            IQueryable<Salao> query =
                this.repositorioSaloes
                .AllAsNoTracking()
                .OrderBy(x => x.Nome);

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query
                    .Where(x => x.Nome.ToLower()
                                .Contains(searchString.ToLower()));
            }

            if (sortId != null)
            {
                query = query
                    .Where(x => x.IdCategoria == sortId);
            }

            return await query.CountAsync();
        }

        public async Task<IEnumerable<string>> PegaTodosIdsPorCategoriaAsync(int idCategoria)
        {
            var idsSaloes =
                await this.repositorioSaloes
                .All()
                .Where(x => x.IdCategoria == idCategoria)
                .Select(x => x.Id)
                .ToListAsync();
            return idsSaloes;
        }

        public async Task<T> PegaPorIdAsync<T>(string id)
        {
            var salon =
                await this.repositorioSaloes
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return salon;
        }

        public async Task<string> AdicionaAsync(string nome, int idCategoria, int idCidade, string endereco, string urlImagem)
        {
            var salao = new Salao
            {
                Id = Guid.NewGuid().ToString(),
                Nome = nome,
                IdCategoria = idCategoria,
                IdCidade = idCidade,
                Endereco = endereco,
                UrlImagem = urlImagem,
                Avaliacao = 0,
                ContarAvaliadores = 0,
            };

            await this.repositorioSaloes.AddAsync(salao);
            await this.repositorioSaloes.SaveChangesAsync();
            return salao.Id;
        }

        public async Task ExcluiAsync(string id)
        {
            var salao =
                await this.repositorioSaloes
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.repositorioSaloes.Delete(salao);
            await this.repositorioSaloes.SaveChangesAsync();
        }

        public async Task AvaliarSalaoAsync(string id, int valorAvaliacao)
        {
            var salao =
                await this.repositorioSaloes
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var avaliacaoAntiga = salao.Avaliacao;
            var contarAvaliadoresAntigo = salao.ContarAvaliadores;

            var contarAvaliadoresNova = contarAvaliadoresAntigo + 1;
            var avaliacaoNova = (avaliacaoAntiga + valorAvaliacao) / contarAvaliadoresNova;

            salao.Avaliacao = avaliacaoNova;
            salao.ContarAvaliadores = contarAvaliadoresNova;

            await this.repositorioSaloes.SaveChangesAsync();
        }
    }
}
