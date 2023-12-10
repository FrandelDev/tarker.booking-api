using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Database.Customer.Commnads.CreateCustomer;

namespace Tarker.Booking.Application.Validators.Customer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerModel>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(50).NotNull();
            RuleFor(x => x.DocumentNumber).NotEmpty().MaximumLength(8).NotNull();
        }
    }
}
