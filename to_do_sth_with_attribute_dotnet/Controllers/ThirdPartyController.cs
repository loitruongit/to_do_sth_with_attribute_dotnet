using Microsoft.AspNetCore.Mvc;
using to_do_sth_with_attribute_dotnet.AuthorizationFilters;

namespace to_do_sth_with_attribute_dotnet.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ThirdPartyController : ControllerBase
    {
        public ThirdPartyController() { }

        [DenyAllAuthorization]
        [HttpGet]
        [Route("action/deny")]
        public async Task<IActionResult> ActionWillDeny()
        {
            //TODO something
            return Ok();
        }
    }
}
