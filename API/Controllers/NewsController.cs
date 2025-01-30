using Application.Interfaces.Services;
using DTOs;
using DTOs.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Authority")]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        private readonly IAuthorityService _authorityService;

        public NewsController(INewsService newsService, IAuthorityService authorityService)
        {
            _newsService = newsService;
            _authorityService = authorityService;
        }

        private async Task<int> GetCurrentAuthority()
        {
            var userId = User.FindFirstValue("uid");
            int userInt = int.Parse(userId);

            var AuthorityId = await _authorityService.GetByUserId(userInt);

            return AuthorityId.Data;
        }

        [AllowAnonymous]
        [HttpGet("GetNews")]
        public async Task<ActionResult<ServiceResponse<List<GetNewsDto>>>> GetNews()
        {
            return Ok(await _newsService.GetNews());
        }

        [HttpPost("AddNews")]
        public async Task<ActionResult<ServiceResponse<bool>>> AddNews(UpdateNewsDto obj)
        {
            var authorityId = await GetCurrentAuthority();

            return Ok(await _newsService.AddNews(obj, authorityId));
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _newsService.GetById(id);

            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"News with id {id} was not found.");
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> UpdateNews(UpdateNewsDto obj, int id)
        {
            var authorityId = await GetCurrentAuthority();

            return Ok(await _newsService.UpdateNews(obj, id, authorityId));
        }

        [HttpDelete("Delete/{id}")]

        public async Task<ActionResult<ServiceResponse<bool>>> DeleteNews(int id)
        {
            var authorityId = await GetCurrentAuthority();
            return Ok(await _newsService.DeleteNews(id, authorityId));
        }
    }
}
