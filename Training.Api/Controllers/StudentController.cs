using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Training.API.Controllers;
using Training.Application.Services;
using Training.Domain.Entities;
using Training.Domain.Models;

namespace Training.Api.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : Controller
    {
        private readonly ILogger<CoursesController> _logger;
        private IStudentRepository _studentService;
        private readonly IMapper _mapper;

        public StudentController(ILogger<CoursesController> logger, IStudentRepository studentService, IMapper mapper)
        {
            _logger = logger;
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAllStudents()
        {
            var cursos = await _studentService.GetAllStudents();

            return Ok(_mapper.Map<IEnumerable<StudentDTO>>(cursos));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudentById(Guid id)
        {
            try
            {
                var curso = await _studentService.GetStudentById(id);
                if (curso == null)
                {
                    _logger.LogInformation("Este curso no existe!");
                    return NotFound();
                }
                return Ok(_mapper.Map<StudentDTO>(curso));
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Este curso no existe!", ex);
                return StatusCode(500, "Se ha encontrado un problema con tu llamada!");
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentDTO>> DeleteStudent(Guid id)
        {
            try
            {
                _studentService.DeleteStudent(id);
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
        [Route("CreateStudent")]
        public async Task<ActionResult> CreateStudent(StudentDTO studentDTO)
        {
            try
            {
                if (studentDTO == null)
                {
                    return BadRequest();
                }

                var student = new Student
                {
                    Id = Guid.NewGuid(),
                    HoursTaken = studentDTO.HoursTaken,
                    Name = studentDTO.Name,
                    EmailAddress = studentDTO.EmailAddress,
                    RollOnDate = studentDTO.RollOnDate,
                    CommunityName = studentDTO.CommunityName
                };

                await _studentService.CreateStudent(student);

                return Ok(_mapper.Map<StudentDTO>(student));

            }
            catch (Exception ex)
            {
                _logger.LogCritical("no se ha podido añadir el curso!", ex);
                return StatusCode(500, "Se ha encontrado un problema con tu llamada!");
            }

        }

        [HttpPut]
        [Route("UpdateStudent")]
        public async Task<ActionResult> UpdateStudent(StudentDTO studentDTO)
        {
            try
            {
                if (studentDTO == null)
                {
                    return BadRequest();
                }

                var student = new Student
                {
                    Id = studentDTO.Id,
                    HoursTaken = studentDTO.HoursTaken,
                    Name = studentDTO.Name,
                    EmailAddress = studentDTO.EmailAddress,
                    RollOnDate = studentDTO.RollOnDate,
                    CommunityName = studentDTO.CommunityName
                };

                await _studentService.UpdateStudent(student);

                return Ok(_mapper.Map<StudentDTO>(student));

            }
            catch (Exception ex)
            {
                _logger.LogCritical("No se ha podido actualizar el curso!", ex);
                return StatusCode(500, "Se ha encontrado un problema con tu llamada!");
            }

        }
    }
}
