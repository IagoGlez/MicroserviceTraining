using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Training.API.Controllers;
using Training.Application.Services;
using Training.Domain.Entities;
using Training.Domain.Models;
using Training.Persistence.Repositories;

namespace Training.Api.Controllers
{
    [ApiController]
    [Route("api/coach")]
    public class CoachController : Controller
    {
        private readonly ILogger<CoachController> _logger;
        private ICommonRepository<Coach> _commonRepository;
        private readonly IMapper _mapper;

        public CoachController(ILogger<CoachController> logger, ICommonRepository<Coach> commonRepository, IMapper mapper)
        {
            _logger = logger;
            _commonRepository = commonRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoachDTO>>> GetAllCoaches()
        {
            var cursos = await _commonRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<CoachDTO>>(cursos));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CoachDTO>> GetCoachById(Guid id)
        {
            try
            {
                var coach = await _commonRepository.GetById(id);
                if (coach == null)
                {
                    _logger.LogInformation("Este curso no existe!");
                    return NotFound();
                }
                return Ok(_mapper.Map<CoachDTO>(coach));
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Este curso no existe!", ex);
                return StatusCode(500, "Se ha encontrado un problema con tu llamada!");
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CoachDTO>> DeleteCoach(Guid id)
        {
            try
            {
                _commonRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Este profesor no existe, no se puede borrar", ex);
                throw new ApplicationException("Test para probar si funciona el middleware");
            }

        }

        [HttpPost]
        [Route("CreateCoach")]
        public async Task<ActionResult> CreateCoach(CoachDTO coachDTO)
        {
            try
            {
                if (coachDTO == null)
                {
                    return BadRequest();
                }

                var coach = new Coach
                {
                    Id = Guid.NewGuid(),
                    ExperienceYears = coachDTO.ExperienceYears,
                    Name = coachDTO.Name,
                    EmailAddress = coachDTO.EmailAddress,
                    RollOnDate = coachDTO.RollOnDate,
                    CommunityName = coachDTO.CommunityName
                };

                await _commonRepository.Create(coach);

                return Ok(_mapper.Map<CoachDTO>(coach));

            }
            catch (Exception ex)
            {
                _logger.LogCritical("no se ha podido añadir el curso!", ex);
                return StatusCode(500, "Se ha encontrado un problema con tu llamada!");
            }

        }

        [HttpPut]
        [Route("UpdateCoach")]
        public async Task<ActionResult> UpdateCoach(CoachDTO coachDTO)
        {
            try
            {
                if (coachDTO == null)
                {
                    return BadRequest();
                }

                var coach = new Coach
                {
                    Id = coachDTO.Id,
                    ExperienceYears = coachDTO.ExperienceYears,
                    Name = coachDTO.Name,
                    EmailAddress = coachDTO.EmailAddress,
                    RollOnDate = coachDTO.RollOnDate,
                    CommunityName = coachDTO.CommunityName
                };

                await _commonRepository.Update(coach);

                return Ok(_mapper.Map<CoachDTO>(coach));

            }
            catch (Exception ex)
            {
                _logger.LogCritical("No se ha podido actualizar el curso!", ex);
                return StatusCode(500, "Se ha encontrado un problema con tu llamada!");
            }

        }
    }
}
