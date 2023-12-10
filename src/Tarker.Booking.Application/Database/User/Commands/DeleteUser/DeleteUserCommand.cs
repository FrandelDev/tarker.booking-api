using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;

namespace Tarker.Booking.Application.Database.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly IDatabaseService databaseService;

        public DeleteUserCommand(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        public async Task<bool> Execute(int userId)
        {

            var entity = await this.databaseService.User.FirstOrDefaultAsync(x => x.UserId == userId);
            if (entity == null) return false;
            this.databaseService.User.Remove(entity);
            return await databaseService.SaveAsync();
        }
    }
}
