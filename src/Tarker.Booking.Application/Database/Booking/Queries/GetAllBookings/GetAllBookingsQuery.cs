using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;

namespace Tarker.Booking.Application.Database.Booking.Queries.GetAllBookings
{
    public class GetAllBookingsQuery : IGetAllBookingsQuery
    {
        private readonly IDatabaseService service;
        private readonly IMapper mapper;

        public GetAllBookingsQuery(IDatabaseService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<List<GetAllBookingsModel>> Execute()
        {
            var result = await (from booking in service.Booking
                                join customer in service.Customer
                                on booking.CustomerId equals customer.CustomerId
                                select new GetAllBookingsModel
                                {
                                    BookingId = booking.BookingId,
                                    Code = booking.Code,
                                    RegisterDate = booking.RegisterDate,
                                    Type = booking.Type,
                                    CustomerFullName = customer.FullName,
                                    CustomerDocNumber = customer.DocumentNumber
                                }).ToListAsync();
            return result;

            //var entities = await this.service.Booking.ToListAsync();
            //return this.mapper.Map<List<GetAllBookingsModel>>(entities);
        }
    }
}
