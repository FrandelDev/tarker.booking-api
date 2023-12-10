using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Interfaces;

namespace Tarker.Booking.Application.Database.Customer.Queries.GetAllCustomers
{
    public class GetCustomerByIdQuery : IGetCustomerByIdQuery
    {
        private readonly IDatabaseService service;
        private readonly IMapper mapper;

        public GetCustomerByIdQuery(IDatabaseService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<GetCustomerByIdModel> Execute(int customerId)
        {
            var entity = await this.service.Customer.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            return this.mapper.Map<GetCustomerByIdModel>(entity);
        }
    }
}
