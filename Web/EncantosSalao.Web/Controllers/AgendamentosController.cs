namespace EncantosSalao.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using EncantosSalao.Dado.Modelos;
    using EncantosSalao.Servicos.Dado.Agendamentos;
    using EncantosSalao.Servicos.Dado.Saloes;
    using EncantosSalao.Servicos.Dado.ServicosSalaoServico;
    using EncantosSalao.Servicos.DateTimeParser;
    using EncantosSalao.Web.VisaoModelos.Agendamentos;
    using EncantosSalao.Web.VisaoModelos.SalaoServicos;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class AgendamentosController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDateTimeParserService dateTimeParserService;
        private readonly ISaloesServico servicoSaloes;
        private readonly IAgendamentosServico servicoAgendamentos;
        private readonly ISalaoServicosServico servicoSaloeServicos;

        public AgendamentosController(
            UserManager<ApplicationUser> userManager,
            IAgendamentosServico servicoAgendamentos,
            ISalaoServicosServico servicoSaloeServicos,
            IDateTimeParserService dateTimeParserService,
            ISaloesServico servicoSaloes)
        {
            this.userManager = userManager;
            this.servicoAgendamentos = servicoAgendamentos;
            this.servicoSaloeServicos = servicoSaloeServicos;
            this.dateTimeParserService = dateTimeParserService;
            this.servicoSaloes = servicoSaloes;
        }

        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var userId = await this.userManager.GetUserIdAsync(user);

            var viewModel = new AgendamentosListaVisaoModelo
            {
                Agendamentos =
                    await this.servicoAgendamentos.PegaProximosPorUsuarioAsync<AgendamentoVisaoModelo>(userId),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> FacaUmAgendamento(string idSalao, int idServico)
        {
            var servicoSalao = await this.servicoSaloeServicos.PegaPorIdAsync<SalaoServicoSimplesVisaoModelo>(idSalao, idServico);
            if (servicoSalao == null || !servicoSalao.Disponivel)
            {
                return this.View("UnavailableService");
            }

            var viewModel = new AgendamentoEntradaModelo
            {
                IdSalao = idSalao,
               IdServico = idServico,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> FacaUmAgendamento(AgendamentoEntradaModelo input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("FacaUmAgendamento", new { input.IdSalao, input.IdServico });
            }

            DateTime dateTime;
            try
            {
                dateTime = this.dateTimeParserService.ConvertStrings(input.Data, input.Hora);
            }
            catch (System.Exception)
            {
                return this.RedirectToAction("FacUmAgendamento", new { input.IdSalao, input.IdServico });
            }

            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var userId = await this.userManager.GetUserIdAsync(user);

            await this.servicoAgendamentos.AdicionaAsync(userId, input.IdSalao, input.IdServico, dateTime);

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CancelaAgendamento(string id)
        {
            var viewModel = await this.servicoAgendamentos.PegaPorIdAsync<AgendamentoVisaoModelo>(id);

            if (viewModel == null)
            {
                return new StatusCodeResult(404);
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ExcluiAgendamento(string id)
        {
            await this.servicoAgendamentos.ExcluiAsync(id);

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> AvaliacaoUltimoAgendamento(string id)
        {
            var viewModel = await this.servicoAgendamentos.PegaPorIdAsync<AgendamentoAvaliacaoVisaoModelo>(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AvaliacaoSalao(AgendamentoAvaliacaoVisaoModelo avaliacao)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("AvaliacaoUltimoAgendamento", new { id = avaliacao.Id });
            }

            if (avaliacao.EstaSalaoAvaliadoPeloUsuario == true)
            {
                return this.RedirectToAction("RAvaliacaoUltimoAgendamento", new { id = avaliacao.Id });
            }

            await this.servicoAgendamentos.AvaliaAgendamentoAsync(avaliacao.Id);
            await this.servicoSaloes.AvaliarSalaoAsync(avaliacao.IdSalao, avaliacao.ValorAvaliado);

            return this.RedirectToAction("Details", "Saloes", new { id = avaliacao.IdSalao });
        }
    }
}
