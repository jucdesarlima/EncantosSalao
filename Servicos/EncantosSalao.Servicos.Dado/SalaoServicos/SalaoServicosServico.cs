namespace EncantosSalao.Servicos.Dado.ServicosSalaoServico
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EncantosSalao.Dado.Comum.Repositorios;
    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Mapeamento;
    using Microsoft.EntityFrameworkCore;

    public class SalaoServicosServico : ISalaoServicosServico
    {
        private readonly IRepositorioEntidadeDeletavel<ServicoSalao> repositorioServicosSalao;

        public SalaoServicosServico(IRepositorioEntidadeDeletavel<ServicoSalao> repositorioServicosSalao)
        {
            this.repositorioServicosSalao = repositorioServicosSalao;
        }

        public async Task<T> PegaPorIdAsync<T>(string idSalao, int idServico)
        {
            var servicoSalao =
                await this.repositorioServicosSalao
                .All()
                .Where(x => x.IdSalao == idSalao && x.IdServico == idServico)
                .To<T>().FirstOrDefaultAsync();
            return servicoSalao;
        }

        public async Task AdicionaAsync(string idSalao, IEnumerable<int> idsServicos)
        {
            foreach (var idServico in idsServicos)
            {
                await this.repositorioServicosSalao.AddAsync(new ServicoSalao
                {
                    IdSalao = idSalao,
                    IdServico = idServico,
                    Disponivel = true,
                });
            }

            await this.repositorioServicosSalao.SaveChangesAsync();
        }

        public async Task AdicionaAsync(IEnumerable<string> idsSaloes, int idServico)
        {
            foreach (var idSalao in idsSaloes)
            {
                await this.repositorioServicosSalao.AddAsync(new ServicoSalao
                {
                    IdSalao = idSalao,
                    IdServico = idServico,
                    Disponivel = true,
                });
            }

            await this.repositorioServicosSalao.SaveChangesAsync();
        }

        public async Task AlteraStatusDisponivelAsync(string idSalao, int idServico)
        {
            var servicoSalao =
                await this.repositorioServicosSalao
                .All()
                .Where(x => x.IdSalao == idSalao
                            && x.IdServico == idServico)
                .FirstOrDefaultAsync();

            servicoSalao.Disponivel = !servicoSalao.Disponivel;

            await this.repositorioServicosSalao.SaveChangesAsync();
        }
    }
}
