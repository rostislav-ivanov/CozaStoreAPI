using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozaStoreAPI.Controllers
{
    [Authorize]
    //[AutoValidateAntiforgeryToken]
    public class BaseController : ControllerBase
    {
    }
}
