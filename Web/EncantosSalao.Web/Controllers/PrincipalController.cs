namespace EncantosSalao.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using EncantosSalao.Common;
    using EncantosSalao.Services.Data.BlogPosts;
    using EncantosSalao.Services.Data.Categories;
    using EncantosSalao.Web.ViewModels;
    using EncantosSalao.Web.ViewModels.Principal;
    using Microsoft.AspNetCore.Mvc;

    public class PrincipalController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IBlogPostsService blogPostsService;

        public PrincipalController(
            ICategoriesService categoriesService,
            IBlogPostsService blogPostsService)
        {
            this.categoriesService = categoriesService;
            this.blogPostsService = blogPostsService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexViewModel
            {
                Categories =
                    await this.categoriesService.GetAllAsync<IndexCategoryViewModel>(
                        GlobalConstants.SeededDataCounts.Categories),
            };
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [Route("/Principal/Error/404")]
        public IActionResult Error404()
        {
            return this.View();
        }

        [Route("/Principal/Error/{code:int}")]
        public IActionResult Error(int code)
        {
            // Could handle different codes here
            // or just return the default error view
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
