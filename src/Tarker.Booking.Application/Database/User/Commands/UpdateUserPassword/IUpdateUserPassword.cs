using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Database.User.Commands.UpdateUser;

namespace Tarker.Booking.Application.Database.User.Commands.UpdateUserPassword
{
    public interface IUpdateUserPassword
    {
        Task<bool> Execute(UpdateUserPasswordModel model);
    }
}
