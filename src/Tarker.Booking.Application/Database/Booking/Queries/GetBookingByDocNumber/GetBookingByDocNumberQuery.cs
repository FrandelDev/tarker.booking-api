using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;

namespace Tarker.Booking.Application.Database.Booking.Queries.GetBookingByDocNumber
{
    public class GetBookingByDocNumberQuery : IGetBookingByDocNumberQuery
    {
        private readonly IDatabaseService service;

        public GetBookingByDocNumberQuery(IDatabaseService service)
        {
            this.service = service;
            ;
        }
        public async Task<List<GetBookingByDocNumberModel>> Execute(string docNumber)
        {
            var result = await (
                from booking in service.Booking
                join customer in service.Customer
                on booking.CustomerId equals customer.CustomerId
                where customer.DocumentNumber == docNumber
                select new GetBookingByDocNumberModel
                {

                    Code = booking.Code,
                    RegisterDate = booking.RegisterDate,
                    Type = booking.Type
                }
                ).ToListAsync();
            return result;
        }

    }
}
