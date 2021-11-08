﻿namespace EncantosSalao.Web.Infraestrutura.ViewComponents
{
    using System.Threading.Tasks;

    using EncantosSalao.Servicos.Dado.Categorias;
    using EncantosSalao.Web.VisaoModelos.Categorias;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesSimpleListViewComponent : ViewComponent
    {
        private readonly ICategoriasServico categoriesService;

        public CategoriesSimpleListViewComponent(ICategoriasServico categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new CategoriasSimplesListaVisaoModelo
            {
                Categorias = await this.categoriesService.PegaTodosAsync<CategoriaSimplesVisaoModelo>(),
            };

            return this.View(viewModel);
        }
    }
}
