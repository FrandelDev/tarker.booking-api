using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.Database.Customer.Queries.GetCustomerByDocNumber
{
    public interface IGetCustomerByDocNumberQuery
    {
        Task<GetCustomerByDocNumberModel> Execute(string docNumber);
    }
}
