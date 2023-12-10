using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Interfaces;

namespace Tarker.Booking.Application.Database.Booking.Queries.GetBookingByType
{
    public class GetBookingByTypeQuery : IGetBookingByTypeQuery
    {
        private readonly IDatabaseService service;

        public GetBookingByTypeQuery(IDatabaseService service)
        {
            this.service = service;
        }
        public async Task<List<GetBookingByTypeModel>> Execute(string type)
        {
            var result = await (
                from booking in service.Booking
                join customer in service.Customer
                on booking.CustomerId equals customer.CustomerId
                where booking.Type == type
                select new GetBookingByTypeModel
                {
                    Code = booking.Code,
                    Type = booking.Type,
                    RegisterDate = booking.RegisterDate,
                    DocumentNumber = customer.DocumentNumber,
                    FullName = customer.FullName
                }
                ).ToListAsync();
            return result;
        }
    }
}
