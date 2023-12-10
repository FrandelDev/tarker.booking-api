using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Tarker.Booking.Application.Database.Customer.Commnads.CreateCustomer;
using Tarker.Booking.Application.Database.Customer.Commnads.DeleteCustomer;
using Tarker.Booking.Application.Database.Customer.Commnads.UpdateCustomer;
using Tarker.Booking.Application.Database.Customer.Queries.GetAllCustomers;
using Tarker.Booking.Application.Database.Customer.Queries.GetCustomerByDocNumber;
using Tarker.Booking.Application.Exeptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/v1/customer")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CustomerController : ControllerBase
    {

        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateCustomerModel model,
            [FromServices] ICreateCustomerCommand create,
            [FromServices] IValidator<CreateCustomerModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if(!validate.IsValid) return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors.Count.ToString() + " Errores", validate.Errors));

            var data = await create.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, "Success", data));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromServices] IUpdateCustomerCommand update, 
            [FromBody] UpdateCustomerModel model,
            [FromServices] IValidator<UpdateCustomerModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid) return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors.Count.ToString() + " Errores", validate.Errors));
            var data = await update.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, "", data));
        }


        [HttpDelete("delete/{customerId}")]
        public async Task<IActionResult> Delete([FromServices] IDeleteCustomerCommand command, int customerId)
        {
            if (customerId == 0) return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
            var data = await command.Execute(customerId);
            if (!data) return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, "deleted", data));
        }

        [HttpGet("get-all-customers")]
        public async Task<IActionResult> GetAllCustomers([FromServices] IGetAllCustomersQuery query)
        {
            var data = await query.Execute();
            if (data == null) return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, "all customers", data));

        }

        [HttpGet("get-customer/{customerId}")]
        public async Task<IActionResult> GetCustomer([FromServices] IGetCustomerByIdQuery query, int customerId)
        {
            var data = await query.Execute(customerId);
            if (data == null) return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, $"customer: {customerId}", data));
        }

        [HttpGet("get-customer-by-docnumber/{docnumber}")]
        public async Task<IActionResult> GetCustomer([FromServices] IGetCustomerByDocNumberQuery query, string docnumber)
        {
            var data = await query.Execute(docnumber);
            if (data == null) return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, $"customer: {docnumber}", data));
        }
    }
}
