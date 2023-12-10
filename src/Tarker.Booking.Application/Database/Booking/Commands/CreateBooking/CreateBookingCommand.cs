using AutoMapper;
using Tarker.Booking.Application.Interfaces;
using Tarker.Booking.Domain.Entities.Booking;

namespace Tarker.Booking.Application.Database.Booking.Commands.CreateBooking
{
    public class CreateBookingCommand : ICreateBookingCommand
    {
        private readonly IDatabaseService service;
        private readonly IMapper mapper;

        public CreateBookingCommand(IDatabaseService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<CreateBookingModel> Execute(CreateBookingModel model)
        {
            var entity = this.mapper.Map<BookingEntity>(model);
            await this.service.Booking.AddAsync(entity);
            await this.service.SaveAsync();
            return model;
        }
    }
}
