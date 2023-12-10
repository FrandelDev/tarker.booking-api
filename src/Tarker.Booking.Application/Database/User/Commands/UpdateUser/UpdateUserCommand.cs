using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Interfaces;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.Database.User.Commands.UpdateUser
{
    public class UpdateUserCommand : IUpdateUserCommand
    {
          private readonly IDatabaseService service;
          private readonly IMapper mapper;
        public UpdateUserCommand(IDatabaseService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<UpdateUserModel> Execute(UpdateUserModel model)
        {
            var entity =  mapper.Map<UserEntity>(model);
            service.User.Update(entity);
            await service.SaveAsync();
           await service.User.Entry(entity).ReloadAsync();
            return model;
        }
    }
}
