using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Database.Booking.Commands.CreateBooking;

namespace Tarker.Booking.Application.Validators.Booking
{
    public class CreateBookingValidator : AbstractValidator<CreateBookingModel>
    {
        public CreateBookingValidator()
        {
            RuleFor(x => x.RegisterDate).NotEmpty().NotNull();
            RuleFor(x => x.Code).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.Type).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.UserId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.CustomerId).NotEmpty().NotNull().GreaterThan(0);

        }
    }
}
