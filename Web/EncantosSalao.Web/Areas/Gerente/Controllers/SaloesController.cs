namespace EncantosSalao.Web.Areas.Gerente.Controllers
{
    using System.Threading.Tasks;

    using EncantosSalao.Servicos.Dado.Agendamentos;
    using EncantosSalao.Servicos.Dado.Saloes;
    using EncantosSalao.Servicos.Dado.ServicosSalaoServico;
    using EncantosSalao.Web.VisaoModelos.Saloes;
    using Microsoft.AspNetCore.Mvc;

    public class SaloesController : GerenteBaseController
    {
        private readonly ISaloesServico servicoSaloes;
        private readonly ISalaoServicosServico servicoSalaoServicos;
        private readonly IAgendamentosServico servicoAgendamentos;

        public SaloesController(
            ISaloesServico servicoSaloes,
            ISalaoServicosServico servicoSalaoServicos,
            IAgendamentosServico servicoAgendamentos)
        {
            this.servicoSaloes = servicoSaloes;
            this.servicoSalaoServicos = servicoSalaoServicos;
            this.servicoAgendamentos = servicoAgendamentos;
        }

        public async Task<IActionResult> Detalhes(string id)
        {
            var viewModel = await this.servicoSaloes.PegaPorIdAsync<SalaoComServicosVisaoModelo>(id);

            if (viewModel == null)
            {
                return new StatusCodeResult(404);
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AlteraServicoDisponivelStatus(string idSalao, int idServico)
        {
            await this.servicoSalaoServicos.AlteraStatusDisponivelAsync(idSalao, idServico);

            return this.RedirectToAction("Detalhes", new { id = idSalao });
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmaAgendamento(string id, string idSalao)
        {
            await this.servicoAgendamentos.ConfirmaAsync(id);
            return this.RedirectToAction("Detalhes", new { id = idSalao });
        }

        [HttpPost]
        public async Task<IActionResult> RecusaAgendamento(string id, string idSalao)
        {
            await this.servicoAgendamentos.RecusaAsync(id);
            return this.RedirectToAction("Detalhes", new { id = idSalao });
        }
    }
}
