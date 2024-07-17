using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Training.Application.Services;
using Training.Domain.Entities;
using Training.Domain.Models;
using AutoMapper;

namespace Training.API.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {

        private readonly ILogger<CoursesController> _logger;
        private readonly ICoursesRepository _courseRepository;
        private readonly IMapper _mapper;

        public CoursesController(ILogger<CoursesController> logger, ICoursesRepository courseRepository, IMapper mapper)
        {
            _logger = logger;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetAllCourses()
        {
            var cursos = await _courseRepository.GetAllCourses();

            return Ok(_mapper.Map<IEnumerable<CourseDTO>>(cursos));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDTO>> GetCourseById(Guid id)
        {
            try
            {
                var curso = await _courseRepository.GetCourseById(id);
                if (curso == null)
                {
                    _logger.LogInformation("Este curso no existe!");
                    return NotFound();
                }
                return Ok(_mapper.Map<CourseDTO>(curso));
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Este curso no existe!", ex);
                return StatusCode(500, "Se ha encontrado un problema con tu llamada!");
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CourseDTO>> DeleteCourse(Guid id)
        {
            try
            {
                _courseRepository.DeleteCourse(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Este curso no existe, no se puede borrar", ex);
                throw new ApplicationException("Test para probar si funciona el middleware");
                //return StatusCode(500, "Se ha encontrado un problema con tu llamada!");
            }

        }

        [HttpPost]
        [Route("CreateCourse")]
        public async Task<ActionResult> CreateCourse(CourseDTO courseDTO)
        {
            try
            {
                if (courseDTO == null)
                {
                    return BadRequest();
                }

                var course = new Course
                {
                    Id = Guid.NewGuid(),
                    Name = courseDTO.NameCourse,
                    MaxNumberOfStudents = courseDTO.MaxNumberOfStudents,
                    StartDate = courseDTO.StartDate
                };

                await _courseRepository.CreateCourse(course);

                return Ok(_mapper.Map<CourseDTO>(course));

            }
            catch (Exception ex)
            {
                _logger.LogCritical("no se ha podido añadir el curso!", ex);
                return StatusCode(500, "Se ha encontrado un problema con tu llamada!");
            }

        }

        [HttpPut]
        [Route("UpdateCurso")]
        public async Task<ActionResult> UpdateCurso(CourseDTO courseDTO)
        {
            try
            {
                if (courseDTO == null)
                {
                    return BadRequest();
                }

                var course = new Course
                {
                    Id = courseDTO.Id,
                    Name = courseDTO.NameCourse,
                    MaxNumberOfStudents = courseDTO.MaxNumberOfStudents,
                    StartDate = courseDTO.StartDate
                };

                await _courseRepository.UpdateCourse(course);

                return Ok(_mapper.Map<CourseDTO>(course));

            }
            catch (Exception ex)
            {
                _logger.LogCritical("No se ha podido actualizar el curso!", ex);
                return StatusCode(500, "Se ha encontrado un problema con tu llamada!");
            }

        }
    }
}
