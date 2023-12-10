using AutoMapper;
using Tarker.Booking.Application.Interfaces;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.Database.User.Commands.CreateUser
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly IDatabaseService databaseService;
        private readonly IMapper mapper;

        public CreateUserCommand(IDatabaseService databaseService, IMapper mapper)
        {
            this.databaseService = databaseService;
            this.mapper = mapper;
        }
        public async Task<CreateUserModel> Execute(CreateUserModel model)
        {
            var entity = this.mapper.Map<UserEntity>(model);
            await this.databaseService.User.AddAsync(entity);
            await this.databaseService.SaveAsync();

            return model;
        }
    }
}
