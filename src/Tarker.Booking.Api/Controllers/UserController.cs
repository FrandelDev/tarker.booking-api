using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.Database.User.Commands.CreateUser;
using Tarker.Booking.Application.Database.User.Commands.DeleteUser;
using Tarker.Booking.Application.Database.User.Commands.UpdateUser;
using Tarker.Booking.Application.Database.User.Commands.UpdateUserPassword;
using Tarker.Booking.Application.Database.User.Queries.GetAllUsers;
using Tarker.Booking.Application.Database.User.Queries.GetUser;
using Tarker.Booking.Application.Database.User.Queries.GetUserByUsernameAndPasword;
using Tarker.Booking.Application.Exeptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class UserController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateUserModel model,
            [FromServices] ICreateUserCommand create,
            [FromServices] IValidator<CreateUserModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid) return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors.Count.ToString() + " Errores", validate.Errors));
            var data = await create.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, "Success", data));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateUserModel model,
            [FromServices] IUpdateUserCommand update,
            [FromServices] IValidator<UpdateUserModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid) return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors.Count.ToString() + " Errores", validate.Errors));
            var data = await update.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, "", data));
        }

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword(
            [FromServices] IUpdateUserPassword command,
            [FromBody] UpdateUserPasswordModel model,
            [FromServices] IValidator<UpdateUserPasswordModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid) return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors.Count.ToString() + " Errores", validate.Errors));
            var data = await command.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, "", data));
        }

        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> Delete([FromServices] IDeleteUserCommand command, int userId)
        {
            if (userId == 0) return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
            var data = await command.Execute(userId);
            if (!data) return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, "deleted", data));
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers([FromServices] IGetAllUsersQuery query)
        {
            var data = await query.Execute();
            if (data == null) return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, "all users", data));

        }

        [HttpGet("get-user/{userId}")]
        public async Task<IActionResult> GetUser([FromServices] IGetUserByIdQuery query, int userId)
        {
            var data = await query.Execute(userId);
            if (data == null) return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, $"user: {userId}", data));
        }

        [HttpGet("get-user-by-username-and-password/{username}/{pwd}")]
        public async Task<IActionResult> GetUser([FromServices] IGetUserByUsernameAndPasswordQuery query, string username, string pwd)
        {
            var data = await query.Execute(username, pwd);
            if (data == null) return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, $"user: {username}", data));
        }
    }
}
