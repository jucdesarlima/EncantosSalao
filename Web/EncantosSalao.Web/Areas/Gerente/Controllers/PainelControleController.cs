namespace EncantosSalao.Web.Areas.Gerente.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class PainelControleController : GerenteBaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
