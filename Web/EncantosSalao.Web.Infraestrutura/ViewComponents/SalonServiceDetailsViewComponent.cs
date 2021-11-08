namespace EncantosSalao.Web.Infraestrutura.ViewComponents
{
    using System.Threading.Tasks;

    using EncantosSalao.Servicos.Dado.ServicosSalaoServico;
    using EncantosSalao.Web.VisaoModelos.SalaoServicos;
    using Microsoft.AspNetCore.Mvc;

    public class SalonServiceDetailsViewComponent : ViewComponent
    {
        private readonly ISalaoServicosServico servicosSalaoServico;

        public SalonServiceDetailsViewComponent(ISalaoServicosServico servicosSalaoServico)
        {
            this.servicosSalaoServico = servicosSalaoServico;
        }

        public async Task<IViewComponentResult> InvokeAsync(string idSalao, int idServico)
        {
            var viewModel =
                await this.servicosSalaoServico.PegaPorIdAsync<SalaoServicoDetalhesVisaoModelo>(idSalao, idServico);

            return this.View(viewModel);
        }
    }
}
