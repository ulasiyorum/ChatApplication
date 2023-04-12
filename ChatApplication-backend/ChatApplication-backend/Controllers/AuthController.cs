using ChatApplication_backend.Services.AuthService;

namespace ChatApplication_backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        public readonly IAuthService service;

        public AuthController(IAuthService serv)
        {
            service = serv;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Register(AddUserDto dto)
        {
            return Ok(await service.Register(dto));
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Login(string username, string password)
        {
            return Ok(await service.Login(username, password));
        }
    }
}
