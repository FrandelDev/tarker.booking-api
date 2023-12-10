using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Database.User.Queries.GetUser;

namespace Tarker.Booking.Application.Database.User.Queries.GetUserByUsernameAndPasword
{
    public interface IGetUserByUsernameAndPasswordQuery
    {
        Task<GetUserByUsernameAndPasswordModel> Execute(string username, string password);
    }
}
