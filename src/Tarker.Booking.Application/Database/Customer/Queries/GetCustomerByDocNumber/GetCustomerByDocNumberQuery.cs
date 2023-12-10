using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Interfaces;

namespace Tarker.Booking.Application.Database.Customer.Queries.GetCustomerByDocNumber
{
    internal class GetCustomerByDocNumberQuery : IGetCustomerByDocNumberQuery
    {
        private readonly IDatabaseService service;
        private readonly IMapper mapper;

        public GetCustomerByDocNumberQuery(IDatabaseService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<GetCustomerByDocNumberModel> Execute(string docNumber)
        {
            var entity = await this.service.Customer.FirstOrDefaultAsync(x => x.DocumentNumber == docNumber);
            return this.mapper.Map<GetCustomerByDocNumberModel>(entity);
        }
    }
}
