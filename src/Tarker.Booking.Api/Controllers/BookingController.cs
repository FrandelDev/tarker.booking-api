using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.Database.Booking.Commands.CreateBooking;
using Tarker.Booking.Application.Database.Booking.Commands.DeleteBooking;
using Tarker.Booking.Application.Database.Booking.Queries.GetAllBookings;
using Tarker.Booking.Application.Database.Booking.Queries.GetBookingByDocNumber;
using Tarker.Booking.Application.Database.Booking.Queries.GetBookingByType;
using Tarker.Booking.Application.Exeptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/v1/booking")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class BookingController : ControllerBase
    {

        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateBookingModel model,
            [FromServices] ICreateBookingCommand create,
            [FromServices] IValidator<CreateBookingModel> validator)
        {

            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid) return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors.Count.ToString() + " Errores", validate.Errors));

            var data = await create.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, "Success", data));
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Detete([FromServices] IDeleteBookingCommand command, int bookingId)
        {
            if (bookingId == 0) return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
            bool status = await  command.Execute(bookingId);
            if(!status) return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, "deleted"));
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, "deleted"));
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllBookings([FromServices] IGetAllBookingsQuery query)
        {
            var data = await query.Execute();
            if (data.Count == 0) return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, "all bookings", data));

        }

        [HttpGet("get-booking/{docnumber}")]
        public async Task<IActionResult> GetBooking([FromServices] IGetBookingByDocNumberQuery query, string docnumber)
        {
            var data = await query.Execute(docnumber);
            if (data == null) return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, $"booking: {docnumber}", data));
        }

        [HttpGet("get-by-type/{type}")]
        public async Task<IActionResult> GetBookingByType([FromServices] IGetBookingByTypeQuery query, string type)
        {
            var data = await query.Execute(type);
            if (data == null) return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, $"booking: {type}", data));
        }
    }
}
