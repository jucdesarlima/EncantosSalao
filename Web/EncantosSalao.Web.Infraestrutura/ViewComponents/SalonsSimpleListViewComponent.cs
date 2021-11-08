namespace EncantosSalao.Web.Infraestrutura.ViewComponents
{
    using System.Threading.Tasks;

    using EncantosSalao.Servicos.Dado.Saloes;
    using EncantosSalao.Web.VisaoModelos.Saloes;
    using Microsoft.AspNetCore.Mvc;

    public class SalonsSimpleListViewComponent : ViewComponent
    {
        private readonly ISaloesServico servicoSalao;

        public SalonsSimpleListViewComponent(ISaloesServico servicoSalao)
        {
            this.servicoSalao = servicoSalao;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // This is used as a Menu in Salon Manager Area
            // Now only the Admin can Add Salons and only the seeded Manager can manage all of them
            // When Registering a Salon becomes an option for every user, UserId (OwnerId for Salons) would be checked here
            var viewModel = new SaloesListaSimplesVisaoModelo
            {
                Saloes = await this.servicoSalao.PegaTodosAsync<SalaoSimplesVisaoModelo>(),
            };

            return this.View(viewModel);
        }
    }
}
