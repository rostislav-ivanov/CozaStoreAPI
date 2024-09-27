using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    //[AutoValidateAntiforgeryToken]
    public class BaseApiController : ControllerBase
    {
    }
}
