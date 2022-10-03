using CollegeManagementPortal.CQRS.Students.Commands;
using CollegeManagementPortal.CQRS.Students.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CollegeManagementPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllStudentsQuery()));
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/<StudentController>/5
        [HttpGet]
        [Route("GetNewRegNum")]
        public async Task<IActionResult> GetNewRegNum()
        {
            return Ok(await _mediator.Send(new GetNewRegNumQuery()));
        }

        [HttpGet]
        [Route("GetAllUnAssigned")]
        public async Task<IActionResult> GetUnAssignedByCourseId()
        {
            return Ok(await _mediator.Send(new GetAllUnAssignedStudentsQuery()));
        }

        [HttpGet]
        [Route("GetAssignedByCourseId")]
        public async Task<IActionResult> GetAssignedByCourseId(int courseId)
        {
            return Ok(await _mediator.Send(new GetAllAssignedStudentsByCourseIdQuery() { CourseId = courseId }));
        }

        [HttpGet]
        [Route("GetStudentReportBySubjectId")]
        public async Task<IActionResult> GetStudentReportBySubjectId(int subjectId)
        {
            return Ok(await _mediator.Send(new GetStudentsReportBySubjectIdQuery() { SubjectId = subjectId }));
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateStudentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
