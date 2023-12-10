using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.Booking;

namespace Tarker.Booking.Persistence.Configuration
{
    internal class BookingConfiguration
    {
        public BookingConfiguration(EntityTypeBuilder<BookingEntity> entityBuilder)
        {
            entityBuilder.HasKey(e => e.BookingId);
            entityBuilder.Property(prop => prop.RegisterDate).IsRequired();
            entityBuilder.Property(prop => prop.Type).IsRequired();
            entityBuilder.Property(prop => prop.Code).IsRequired();
            entityBuilder.Property(prop => prop.UserId).IsRequired();
            entityBuilder.Property(prop => prop.CustomerId).IsRequired();
            entityBuilder.HasOne(prop => prop.User).WithMany(prop => prop.Bookings).HasForeignKey(fk => fk.UserId);
            entityBuilder.HasOne(prop => prop.Customer).WithMany(prop => prop.Bookings).HasForeignKey(fk => fk.CustomerId);
        }
    }
}
