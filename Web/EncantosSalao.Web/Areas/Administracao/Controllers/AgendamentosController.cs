namespace EncantosSalao.Web.Areas.Administracao.Controllers
{
    using System.Threading.Tasks;

    using EncantosSalao.Services.Dado.Agendamentos;
    using EncantosSalao.Web.VisaoModelos.Agendamentos;
    using Microsoft.AspNetCore.Mvc;

    public class AgendamentosController : AdministracaoController
    {
        private readonly IAgendamentosServico servicoAgendamentos;

        public AgendamentosController(IAgendamentosServico servicoAgendamentos)
        {
            this.servicoAgendamentos = servicoAgendamentos;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new AgendamentoListViewModel
            {
                Agendamentos =
                    await this.servicoAgendamentos.PegaTodosAsync<AgendamentoListViewModel>(),
            };
            return this.View(viewModel);
        }
    }
}
