using Application.Interfaces.Services;
using DTOs;
using DTOs.Professor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Authority")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [AllowAnonymous]
        [HttpGet("GetProfessors")]
        public async Task<ActionResult<ServiceResponse<List<GetProfessorDto>>>> GetProfessors()
        {
            return Ok(await _professorService.GetAllProfessors());
        }

        [HttpGet("GetMasters")]
        public async Task<ActionResult<ServiceResponse<List<GetProfessorDto>>>> GetMasters()
        {
            return Ok(await _professorService.GetMasters());
        }

        [HttpGet("GetBySchoolId/{schoolId}")]
        public async Task<ActionResult<ServiceResponse<List<GetProfessorDto>>>> GetBySchoolId(int schoolId)
        {
            return Ok(await _professorService.GetBySchoolId(schoolId));
        }

        [HttpPut("UpdateProfessor")]
        public async Task<ActionResult<ServiceResponse<bool>>> UpdateProfessor(int id, UpdateProfessorDto updatedProfessor)
        {
            return Ok(await _professorService.UpdateProfessor(id, updatedProfessor));
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _professorService.GetById(id);

            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Professor with id {id} was not found.");
        }
    }
}
