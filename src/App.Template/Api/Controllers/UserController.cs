using System;
using App.Template.Domain.Commons;
using Microsoft.AspNetCore.Mvc;
using App.Template.Api.Adapters.Factories;
using App.Template.Api.Adapters.Requests.User;
using App.Template.Domain.Contracts.UseCase.User;

namespace App.Template.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult FindAll([FromServices] IFindAllUserUseCase useCase)
        {
            try
            {
                return Ok(UserResponseFactory.Build(useCase.FindAll()));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpGet("{id}")]
        public IActionResult FindById([FromServices] IFindByIdUserUseCase useCase, string id)
        {
            try
            {
                var guid = ApiConverter.ToGuid(id);
                return Ok(UserResponseFactory.Build(useCase.FindById(guid)));
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Create([FromServices] ICreateUserUseCase useCase, [FromBody] UserCreateRequest userCreateRequest)
        {
            try
            {
                useCase.Create(UserEntityFactory.Build(userCreateRequest));
                return Created("", null);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromServices] IUpdateUserUseCase useCase, string id, [FromBody] UserUpdateRequest userUpdateRequest)
        {
            try
            {
                var guid = ApiConverter.ToGuid(id);
                useCase.Update(guid, UserEntityFactory.Build(userUpdateRequest));

                return NoContent();
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromServices] IDeleteUserUseCase useCase, string id)
        {
            try
            {
                var guid = ApiConverter.ToGuid(id);
                useCase.Delete(guid);

                return NoContent();
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
