using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Interfaces;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.Database.User.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IGetAllUsersQuery
    {
        private readonly IDatabaseService service;
        private readonly IMapper mapper;

        public GetAllUsersQuery(IDatabaseService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<List<GetAllUsersModel>> Execute()
        {
            var entities = await service.User.ToListAsync();
         return this.mapper.Map<List<GetAllUsersModel>>(entities);
        }
    }
}
