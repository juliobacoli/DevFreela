using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.LoginUser;
using DevFreela.Application.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        // api/users/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserQuery(id);
            var user = await _mediator.Send(query);

            if (user == null)
            {
                return NotFound();
            }
            return Ok();
        }

        // api/users
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserCommand command)
        {
            #region EXEMPLO USANDO MODELSTATE
            //Caso as validações deem errado, ele irá mostrar as mensagens de erro tratadas na classe [...]VALIDATOR
            //if (!ModelState.IsValid)
            //{
            //    var messages = ModelState
            //        .SelectMany(ms => ms.Value.Errors)
            //        .Select(erros => erros.ErrorMessage)
            //        .ToList();

            //    return BadRequest(messages);
            //}
            #endregion

            var id = _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        //api/users/1/login
        [HttpPut("login")]
        public async Task<IActionResult> Login(int id, [FromBody] LoginUserCommand command)
        {
            var loginUserViewModel = await _mediator.Send(command);

            if (loginUserViewModel == null)
                return BadRequest();

            return Ok(loginUserViewModel);
        }
    }
}
