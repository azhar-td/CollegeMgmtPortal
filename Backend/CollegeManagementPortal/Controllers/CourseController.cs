using CollegeManagementPortal.CQRS.Courses.Commands;
using CollegeManagementPortal.CQRS.Courses.Queries;
using CollegeManagementPortal.CQRS.Students.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CollegeManagementPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CourseController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllCoursesQuery()));
        }

        // GET: api/<CourseController>
        [HttpGet]
        [Route("GetCourseReport")]
        public async Task<IActionResult> GetCourseReport()
        {
            return Ok(await _mediator.Send(new GetCoursesReportQuery()));
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetCourseByIdQuery() { Id = id }));
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCourseCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        // POST api/<CourseController>
        [HttpPost]
        [Route("AssignSubjectAndTeacher")]
        public async Task<IActionResult> AssignSubjectAndTeacher([FromBody] CreateCourseDetailCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        // POST api/<CourseController>
        [HttpPost]
        [Route("AssignStudent")]
        public async Task<IActionResult> AssignStudent([FromBody] AssignStudentToCourseCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
