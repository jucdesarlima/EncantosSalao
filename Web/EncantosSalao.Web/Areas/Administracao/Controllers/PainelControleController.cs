namespace EncantosSalao.Web.Areas.Administracao.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class PainelControleController : AdministracaoController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
