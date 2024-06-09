using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BurberDinner.Api.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/errors")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<ExceptionHandlerFeature>()?.Error;
            return Problem(title: exception?.Message, statusCode:400);
        }
    }
}
