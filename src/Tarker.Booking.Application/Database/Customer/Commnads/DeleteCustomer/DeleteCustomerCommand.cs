using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;

namespace Tarker.Booking.Application.Database.Customer.Commnads.DeleteCustomer
{
    public class DeleteCustomerCommand : IDeleteCustomerCommand
    {
        private readonly IDatabaseService service;

        public DeleteCustomerCommand(IDatabaseService service)
        {
            this.service = service;   
        }
        public async Task<bool> Execute(int customerId)
        {
            var entity = await service.Customer.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            if (entity == null) return false;
            this.service.Customer.Remove(entity);
            return await service.SaveAsync();

        }
    }
}
