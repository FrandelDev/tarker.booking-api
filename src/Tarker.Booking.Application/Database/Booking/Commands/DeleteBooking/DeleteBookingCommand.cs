using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;

namespace Tarker.Booking.Application.Database.Booking.Commands.DeleteBooking
{
    public class DeleteBookingCommand : IDeleteBookingCommand
    {
        private readonly IDatabaseService service;

        public DeleteBookingCommand(IDatabaseService service, IMapper mapper)
        {
            this.service = service;
        }
        public async Task<bool> Execute(int bookingId)
        {
            var entity = await this.service.Booking.FirstOrDefaultAsync(x => x.BookingId == bookingId);
            if (entity == null) return false;
            this.service.Booking.Remove(entity);
            return await this.service.SaveAsync();
        }
    }
}
