namespace EncantosSalao.Web.Areas.Administracao.Controllers
{
    using System.Threading.Tasks;

    using EncantosSalao.Comum;
    using EncantosSalao.Servicos.Dado.Categorias;
    using EncantosSalao.Web.VisaoModelos.Categorias;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriasController : AdministracaoController
    {
        private readonly ICategoriasServico servicoCategorias;

        public CategoriasController(
            ICategoriasServico servicoCategorias)
        {
            this.servicoCategorias = servicoCategorias;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new CategoriasListaVisaoModelo
            {
                Categories = await this.servicoCategorias.PegaTodosAsync<CategoriasListaVisaoModelo>(),
            };
            return this.View(viewModel);
        }

        public IActionResult AddCategory()
        {
            return this.View();
        }

        //[HttpPost]
        //public async Task<IActionResult> AddCategory(CategoryInputModel input)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.View(input);
        //    }

        //    string imageUrl;
            
        //    await this.categoriesService.AddAsync(input.Name, input.Description, imageUrl);
        //    return this.RedirectToAction("Index");
        //}

        [HttpPost]
        public async Task<IActionResult> ExcluiCategoria(int id)
        {
            if (id <= ConstantesGlobais.ContadoresDadosSemeados.Categorias)
            {
                return this.RedirectToAction("Index");
            }

            await this.servicoCategorias.ExcluiAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
