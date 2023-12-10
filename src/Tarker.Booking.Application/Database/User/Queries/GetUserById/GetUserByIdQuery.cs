using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Interfaces;

namespace Tarker.Booking.Application.Database.User.Queries.GetUser
{
    public class GetUserByIdQuery : IGetUserByIdQuery
    {
        private readonly IDatabaseService service;
        private readonly IMapper mapper;

        public GetUserByIdQuery(IDatabaseService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<GetUserByIdModel> Execute(int userid)
        {
            var entity = await service.User.FirstOrDefaultAsync(x => x.UserId == userid);
          return  mapper.Map<GetUserByIdModel>(entity);

        }

        
    }
}
