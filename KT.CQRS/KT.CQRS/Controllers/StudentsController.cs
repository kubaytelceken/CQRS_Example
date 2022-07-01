using KT.CQRS.CQRS.Commands;
using KT.CQRS.CQRS.Handlers;
using KT.CQRS.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KT.CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetStudentsQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand createStudentCommand)
        {
            await _mediator.Send(createStudentCommand);
            return Created("",createStudentCommand.Name);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send(new RemoveStudentCommand(id));
            return NoContent();
        } 


        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentCommand updateStudentCommand)
        {
            await _mediator.Send(updateStudentCommand);
            return NoContent();
        }
    }
}
