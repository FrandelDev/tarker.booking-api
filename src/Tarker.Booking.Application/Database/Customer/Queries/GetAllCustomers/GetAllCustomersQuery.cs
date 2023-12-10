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
    internal class GetAllCustomersQuery : IGetAllCustomersQuery
    {
        private readonly IDatabaseService service;
        private readonly IMapper mapper;

        public GetAllCustomersQuery(IDatabaseService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<List<GetAllCustomersModel>> Execute()
        {
            var entities = await this.service.Customer.ToListAsync();
            return this.mapper.Map<List<GetAllCustomersModel>>(entities);
        }
    }
}
