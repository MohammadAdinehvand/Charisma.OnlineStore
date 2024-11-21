using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Charisma.OnlineStore.Api.Controllers
{
    [ApiController]
    [Route($"{Constants.MasterRoute}/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected ActionResult<TResult> OKOrNotFound<TResult>(TResult result)
        {
            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}
