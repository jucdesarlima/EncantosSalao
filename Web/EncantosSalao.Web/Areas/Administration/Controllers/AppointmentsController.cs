namespace EncantosSalao.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using EncantosSalao.Services.Data.Appointments;
    using EncantosSalao.Web.ViewModels.Appointments;
    using Microsoft.AspNetCore.Mvc;

    public class AppointmentsController : AdministrationController
    {
        private readonly IAppointmentsService appointmentsService;

        public AppointmentsController(IAppointmentsService appointmentsService)
        {
            this.appointmentsService = appointmentsService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new AppointmentsListViewModel
            {
                Appointments =
                    await this.appointmentsService.GetAllAsync<AppointmentViewModel>(),
            };
            return this.View(viewModel);
        }
    }
}
