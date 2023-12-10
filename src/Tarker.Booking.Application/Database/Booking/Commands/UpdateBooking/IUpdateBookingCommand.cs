using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.Database.Booking.Commands.UpdateBooking
{
    public interface IUpdateBookingCommand
    {
        Task<UpdateBookingModel> Execute(UpdateBookingModel model);
    }
}
