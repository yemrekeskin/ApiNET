using Microsoft.AspNetCore.Mvc;

namespace ApiNET.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ApiControllerBase
        : ControllerBase
    {
    }
}