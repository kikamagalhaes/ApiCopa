using Microsoft.AspNetCore.Mvc;

namespace apideteste.Controllers
{
    public class TokenController : ControllerBase
    {

        [Route("/token")]
        [HttpHead]
        public ActionResult Index()
        {
            return StatusCode(204);
        }
    }
}
