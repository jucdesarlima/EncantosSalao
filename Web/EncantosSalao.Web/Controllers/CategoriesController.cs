namespace EncantosSalao.Web.Controllers
{
    using System.Threading.Tasks;

    using EncantosSalao.Services.Data.Categories;
    using EncantosSalao.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new CategoriesListViewModel
            {
                Categories = await this.categoriesService.GetAllAsync<CategoryViewModel>(),
            };
            return this.View(viewModel);
        }
    }
}
