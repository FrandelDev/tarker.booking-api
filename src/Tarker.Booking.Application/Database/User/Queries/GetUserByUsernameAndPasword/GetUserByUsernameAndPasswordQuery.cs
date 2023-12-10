using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Database.User.Queries.GetUser;
using Tarker.Booking.Application.Interfaces;

namespace Tarker.Booking.Application.Database.User.Queries.GetUserByUsernameAndPasword
{
    public class GetUserByUsernameAndPasswordQuery : IGetUserByUsernameAndPasswordQuery
    {
        private readonly IDatabaseService service;
        private readonly IMapper mapper;

        public GetUserByUsernameAndPasswordQuery(IDatabaseService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<GetUserByUsernameAndPasswordModel> Execute(string username, string password)
        {
            var entity = await service.User.FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);

            return mapper.Map<GetUserByUsernameAndPasswordModel>(entity);
        }
    }
}
