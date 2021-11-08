namespace EncantosSalao.Web.Infraestrutura.ViewComponents
{
    using System.Threading.Tasks;

    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Dado.Agendamentos;
    using EncantosSalao.Web.VisaoModelos.Agendamentos;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PastAppointmentsViewComponent : ViewComponent
    {
        private readonly IAgendamentosServico servicoAgendamentos;
        private readonly UserManager<ApplicationUser> userManager;

        public PastAppointmentsViewComponent(
            IAgendamentosServico servicoAgendamentos,
            UserManager<ApplicationUser> userManager)
        {
            this.servicoAgendamentos = servicoAgendamentos;
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var userId = await this.userManager.GetUserIdAsync(user);

            var viewModel = new AgendamentosListaVisaoModelo
            {
                Agendamentos =
                    await this.servicoAgendamentos.PegaAnterioresPorUsuarioAsync<AgendamentoVisaoModelo>(userId),
            };

            return this.View(viewModel);
        }
    }
}
