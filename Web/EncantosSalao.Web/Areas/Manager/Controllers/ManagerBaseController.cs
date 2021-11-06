namespace EncantosSalao.Web.Areas.Manager.Controllers
{
    using EncantosSalao.Common;
    using EncantosSalao.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.SalonManagerRoleName)]
    [Area("Manager")]
    public class ManagerBaseController : BaseController
    {
    }
}
