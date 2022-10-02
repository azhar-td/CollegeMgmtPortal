using CollegeManagementPortal.CQRS.Subjects.Commands;
using CollegeManagementPortal.CQRS.Subjects.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CollegeManagementPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<SubjectController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllSubjectsQuery()));
        }

        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("GetUnAssignedByCourseId")]
        public async Task<IActionResult> GetUnAssignedByCourseId(int courseId)
        {
            return Ok(await _mediator.Send(new GetAllUnAssignedSubjectsByCourseIdQuery() { CourseId = courseId }));
        }

        // POST api/<SubjectController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSubjectCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        // PUT api/<SubjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
