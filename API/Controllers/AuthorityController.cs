using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Authority")]
    public class AuthorityController : ControllerBase
    {
        private readonly IAuthorityService _authorityService;

        public AuthorityController(IAuthorityService authorityService)
        {
            _authorityService = authorityService;
        }

    }
}
