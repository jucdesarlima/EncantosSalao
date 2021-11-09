namespace EncantosSalao.Web.Areas.Administracao.Controllers
{
    using System.Threading.Tasks;

    using EncantosSalao.Servicos.Dado.Agendamentos;
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
            var viewModel = new AgendamentosListaVisaoModelo
            {
                Agendamentos =
                    await this.servicoAgendamentos.PegaTodosAsync<AgendamentoVisaoModelo >(),
            };
            return this.View(viewModel);
        }
    }
}
