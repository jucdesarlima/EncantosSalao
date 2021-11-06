﻿namespace EncantosSalao.Web.Infrastructure.ViewComponents
{
    using System.Threading.Tasks;

    using EncantosSalao.Services.Data.SalonServicesServices;
    using EncantosSalao.Web.ViewModels.SalonServices;
    using Microsoft.AspNetCore.Mvc;

    public class SalonServiceDetailsViewComponent : ViewComponent
    {
        private readonly ISalonServicesService salonServicesService;

        public SalonServiceDetailsViewComponent(ISalonServicesService salonServicesService)
        {
            this.salonServicesService = salonServicesService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string salonId, int serviceId)
        {
            var viewModel =
                await this.salonServicesService.GetByIdAsync<SalonServiceDetailsViewModel>(salonId, serviceId);

            return this.View(viewModel);
        }
    }
}
