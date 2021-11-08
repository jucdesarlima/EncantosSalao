namespace EncantosSalao.Web.Areas.Administracao.Controllers
{
    using System.Threading.Tasks;

    using EncantosSalao.Comum;
    using EncantosSalao.Servicos.Dado.Cidades;
    using EncantosSalao.Web.VisaoModelos.Cidades;
    using Microsoft.AspNetCore.Mvc;

    public class CidadesController : AdministracaoController
    {
        private readonly ICidadesServico servicoCidades;

        public CidadesController(ICidadesServico servicoCidades)
        {
            this.servicoCidades = servicoCidades;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new CidadesListaVisaoModelo
            {
                Cidades = await this.servicoCidades.PegaTodosAsync<CidadeVisaoModelo>(),
            };
            return this.View(viewModel);
        }

        public IActionResult AdicionaCidade()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AdicionaCidade(CidadeEntradaModelo input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.servicoCidades.AdicionaAsync(input.Nome);

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ExcluiCidade(int id)
        {
            if (id <= ConstantesGlobais.ContadoresDadosSemeados.Cidades)
            {
                return this.RedirectToAction("Index");
            }

            await this.servicoCidades.ExcluiAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
