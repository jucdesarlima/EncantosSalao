namespace EncantosSalao.Web.Infraestrutura.ViewComponents
{
    using System.Threading.Tasks;

    using EncantosSalao.Servicos.Dado.Agendamentos;
    using EncantosSalao.Web.VisaoModelos.Agendamentos;
    using Microsoft.AspNetCore.Mvc;

    public class AllAppointmentsBySalonViewComponent : ViewComponent
    {
        private readonly IAgendamentosServico servicoAgendamentos;

        public AllAppointmentsBySalonViewComponent(IAgendamentosServico servicoAgendamentos)
        {
            this.servicoAgendamentos = servicoAgendamentos;
        }

        public async Task<IViewComponentResult> InvokeAsync(string idSalao)
        {
            var viewModel = new AgendamentosListaVisaoModelo
            {
                Agendamentos =
                    await this.servicoAgendamentos.PegaTodosPorSalaoAsync<AgendamentoVisaoModelo>(idSalao),
            };

            return this.View(viewModel);
        }
    }
}
