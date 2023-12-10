using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.Database.Booking.Commands.DeleteBooking
{
    public interface IDeleteBookingCommand
    {
        Task<bool> Execute(int bookingId);
    }
}
