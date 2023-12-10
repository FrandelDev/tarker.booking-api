using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Interfaces;
using Tarker.Booking.Domain.Entities.Booking;

namespace Tarker.Booking.Application.Database.Booking.Commands.UpdateBooking
{
    public class UpdateBookingCommand : IUpdateBookingCommand
    {
        private readonly IDatabaseService service;
        private readonly IMapper mapper;

        public UpdateBookingCommand(IDatabaseService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<UpdateBookingModel> Execute(UpdateBookingModel model)
        {
            var entity = this.mapper.Map<BookingEntity>(model);
            this.service.Booking.Update(entity);
            await this.service.SaveAsync();
            return model;
        }
    }
}
