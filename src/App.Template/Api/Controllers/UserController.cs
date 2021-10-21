using System;
using Microsoft.AspNetCore.Mvc;
using App.Template.Domain.Commons;
using App.Template.Api.Adapters.Responses;
using App.Template.Api.Adapters.Requests.User;
using App.Template.Api.Adapters.Factories.User;
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
            catch (Exception ex)
            {
                return NotFound(ErrorResponse.BuildException(ex));
            }
        }
        [HttpGet("{id}")]
        public IActionResult FindById([FromServices] IFindByIdUserUseCase useCase, [FromServices] IUserExistsUseCase userExists, string id)
        {
            try
            {
                var guid = ApiConverter.ToGuid(id);
                if(!userExists.Check(guid)) return NotFound(ErrorResponse.BuildNotFound());

                return Ok(UserResponseFactory.Build(useCase.FindById(guid)));
            }
            catch (FormatException ex)
            {
                return BadRequest(ErrorResponse.BuildException(ex));
            }
            catch (Exception ex)
            {
                return NotFound(ErrorResponse.BuildException(ex));
            }
        }
        [HttpPost]
        public IActionResult Create([FromServices] ICreateUserUseCase useCase, [FromBody] UserCreateRequest userCreateRequest)
        {
            try
            {
                if(!userCreateRequest.Validate()) return BadRequest(ErrorResponse.BuildValidationError());
                
                useCase.Create(UserEntityFactory.Build(userCreateRequest));
                return Created("", null);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ErrorResponse.BuildException(ex));
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorResponse.BuildException(ex));
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromServices] IUpdateUserUseCase useCase, [FromServices] IUserExistsUseCase userExists, string id, [FromBody] UserUpdateRequest userUpdateRequest)
        {
            try
            {
                if(!userUpdateRequest.Validate()) return BadRequest(ErrorResponse.BuildValidationError());

                var guid = ApiConverter.ToGuid(id);

                if(!userExists.Check(guid)) return NotFound(ErrorResponse.BuildNotFound());

                useCase.Update(guid, UserEntityFactory.Build(userUpdateRequest));
                return NoContent();
            }
            catch (FormatException ex)
            {
                return BadRequest(ErrorResponse.BuildException(ex));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ErrorResponse.BuildException(ex));
            }
            catch (Exception ex)
            {
                return NotFound(ErrorResponse.BuildException(ex));
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromServices] IDeleteUserUseCase useCase, [FromServices] IUserExistsUseCase userExists, string id)
        {
            try
            {
                var guid = ApiConverter.ToGuid(id);
                if(!userExists.Check(guid)) return NotFound(ErrorResponse.BuildNotFound());

                useCase.Delete(guid);
                return NoContent();
            }
            catch (FormatException ex)
            {
                return BadRequest(ErrorResponse.BuildException(ex));
            }
            catch (Exception ex)
            {
                return NotFound(ErrorResponse.BuildException(ex));
            }
        }
    }
}
