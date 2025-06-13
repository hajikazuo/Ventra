using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ventra.Mvc.Areas.AdminArea.Controllers
{
    [Authorize]
    [Area("AdminArea")]
    public class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
    }
}
