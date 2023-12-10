using AutoMapper;
using Tarker.Booking.Application.Interfaces;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Application.Database.Customer.Commnads.CreateCustomer
{
    public class CreateCustomerCommand : ICreateCustomerCommand
    {
        private readonly IDatabaseService service;
        private readonly IMapper mapper;

        public CreateCustomerCommand(IDatabaseService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<CreateCustomerModel> Execute(CreateCustomerModel model)
        {
            var entity = this.mapper.Map<CustomerEntity>(model);

            await this.service.Customer.AddAsync(entity);
            await this.service.SaveAsync();
            return model;
        }
    }
}
