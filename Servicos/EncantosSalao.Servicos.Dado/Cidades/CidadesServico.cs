namespace EncantosSalao.Servicos.Dado.Cidades
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EncantosSalao.Dado.Comum.Repositorios;
    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Mapeamento;
    using Microsoft.EntityFrameworkCore;

    public class CidadesServico : ICidadesServico
    {
        private readonly IRepositorioEntidadeDeletavel<Cidade> repositorioCidades;

        public CidadesServico(IRepositorioEntidadeDeletavel<Cidade> repositorioCidades)
        {
            this.repositorioCidades = repositorioCidades;
        }

        public async Task<IEnumerable<T>> PegaTodosAsync<T>()
        {
            var cidades =
                await this.repositorioCidades
                .All()
                .OrderBy(x => x.Id)
                .To<T>().ToListAsync();
            return cidades;
        }

        public async Task AdicionaAsync(string nome)
        {
            await this.repositorioCidades.AddAsync(new Cidade
            {
                Nome = nome,
            });
            await this.repositorioCidades.SaveChangesAsync();
        }

        public async Task ExcluiAsync(int id)
        {
            var cidade =
                await this.repositorioCidades
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.repositorioCidades.Delete(cidade);
            await this.repositorioCidades.SaveChangesAsync();
        }
    }
}
