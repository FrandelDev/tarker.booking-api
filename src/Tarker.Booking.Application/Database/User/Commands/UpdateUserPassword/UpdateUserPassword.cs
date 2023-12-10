using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;

namespace Tarker.Booking.Application.Database.User.Commands.UpdateUserPassword
{
    public class UpdateUserPassword : IUpdateUserPassword
    {
        private readonly IDatabaseService service;

        public async Task<bool> Execute(UpdateUserPasswordModel model)
        {
            var entity = await service.User.FirstOrDefaultAsync(x => x.UserId == model.UserId);
            if (entity == null) return false;
            entity.Password = model.Password;
            return await service.SaveAsync();
        }
    }
}
