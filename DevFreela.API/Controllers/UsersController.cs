using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.LoginUser;
using DevFreela.Application.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

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
        [AllowAnonymous]
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
        [AllowAnonymous]
        public async Task<IActionResult> Login(int id, [FromBody] LoginUserCommand command)
        {
            try
            {
                var loginUserViewModel = await _mediator.Send(command);

                if (loginUserViewModel == null)
                    throw new Exception();

                return Ok(loginUserViewModel);

            }
            catch (Exception ex)
            {

                string message = ex.Message;

                return BadRequest(message);

            }
        }
    }
}
