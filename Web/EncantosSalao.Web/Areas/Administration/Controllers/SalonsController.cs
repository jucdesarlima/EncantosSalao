namespace EncantosSalao.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using EncantosSalao.Common;
    using EncantosSalao.Services.Cloudinary;
    using EncantosSalao.Services.Data.Categories;
    using EncantosSalao.Services.Data.Cities;
    using EncantosSalao.Services.Data.Salons;
    using EncantosSalao.Services.Data.SalonServicesServices;
    using EncantosSalao.Services.Data.Services;
    using EncantosSalao.Web.ViewModels.Common.SelectLists;
    using EncantosSalao.Web.ViewModels.Salons;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class SalonsController : AdministrationController
    {
        private readonly ISalonsService salonsService;
        private readonly ICategoriesService categoriesService;
        private readonly ICitiesService citiesService;
        private readonly IServicesService servicesService;
        private readonly ISalonServicesService salonServicesService;
        private readonly ICloudinaryService cloudinaryService;

        public SalonsController(
            ISalonsService salonsService,
            ICategoriesService categoriesService,
            ICitiesService citiesService,
            IServicesService servicesService,
            ISalonServicesService salonServicesService,
            ICloudinaryService cloudinaryService)
        {
            this.salonsService = salonsService;
            this.categoriesService = categoriesService;
            this.citiesService = citiesService;
            this.servicesService = servicesService;
            this.salonServicesService = salonServicesService;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new SalonsListViewModel
            {
                Salons = await this.salonsService.GetAllAsync<SalonViewModel>(),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> AddSalon()
        {
            var categories = await this.categoriesService.GetAllAsync<CategorySelectListViewModel>();
            var cities = await this.citiesService.GetAllAsync<CitySelectListViewModel>();

            this.ViewData["Categories"] = new SelectList(categories, "Id", "Name");
            this.ViewData["Cities"] = new SelectList(cities, "Id", "Name");

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSalon(SalonInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            string imageUrl;
            try
            {
                imageUrl = await this.cloudinaryService.UploadPictureAsync(input.Image, input.Name);
            }
            catch (System.Exception)
            {
                // In case of missing Cloudinary configuration from appsettings.json
                imageUrl = GlobalConstants.Images.CloudinaryMissing;
            }

            // Add Salon
            var salonId = await this.salonsService.AddAsync(input.Name, input.CategoryId, input.CityId, input.Address, imageUrl);

            // Add to the Salon all Services from its Category
            var servicesIds = await this.servicesService.GetAllIdsByCategoryAsync(input.CategoryId);
            await this.salonServicesService.AddAsync(salonId, servicesIds);

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSalon(string id)
        {
            if (id.StartsWith("seeded"))
            {
                return this.RedirectToAction("Index");
            }

            await this.salonsService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
