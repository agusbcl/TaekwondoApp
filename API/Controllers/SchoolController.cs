using Application.Interfaces.Services;
using DTOs;
using DTOs.School;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Authority")]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolService;
        private readonly IAuthorityService _authorityService;

        public SchoolController(ISchoolService schoolService, IAuthorityService authorityService)
        {
            _schoolService = schoolService;
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
        [HttpGet("GetSchools")]
        public async Task<ActionResult<ServiceResponse<List<GetSchoolDto>>>> GetSchools()
        {
            return Ok(await _schoolService.GetSchools());
        }

        [HttpPost("AddSchool")]
        public async Task<ActionResult<ServiceResponse<bool>>> AddSchool(UpdateSchoolDto school)
        {
            return Ok(await _schoolService.AddSchool(school));
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _schoolService.GetById(id);

            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"School with id {id} was not found.");
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<bool>>> UpdateSchool(int schoolId, UpdateSchoolDto updatedSchool)
        {
            var result = await _schoolService.UpdateSchool(schoolId, updatedSchool);

            if (result != null) 
            {
                return Ok(result);
            }
            return NotFound($"School with id {schoolId} was available to update.");
        }

    }
}
