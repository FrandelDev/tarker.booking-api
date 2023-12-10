using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Database.Customer.Commnads.UpdateCustomer;

namespace Tarker.Booking.Application.Validators.Customer
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerModel>
    {
        public UpdateCustomerValidator() { 
            RuleFor(x => x.CustomerId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(50).NotNull();
            RuleFor(x => x.DocumentNumber).NotEmpty().Length(8).NotNull();
        }
    }
}
