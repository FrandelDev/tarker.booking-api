using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Interfaces;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Application.Database.Customer.Commnads.UpdateCustomer
{
    
    public class UpdateCustomerCommand : IUpdateCustomerCommand
    {
    private readonly IDatabaseService service;
    private readonly IMapper mapper;

        public UpdateCustomerCommand(IDatabaseService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<UpdateCustomerModel> Execute(UpdateCustomerModel model)
        {
            var entity  =  mapper.Map<CustomerEntity>(model);
           service.Customer.Update(entity);
            await service.SaveAsync();
            return model;
        }
    }
}
