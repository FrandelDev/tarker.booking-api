using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Persistence.Configuration
{
    public class UserCofiguration
    {
        public UserCofiguration(EntityTypeBuilder<UserEntity> entityBuilder)
        {
            entityBuilder.HasKey(pk => pk.UserId);
            entityBuilder.Property(prop => prop.FirstName).IsRequired();
            entityBuilder.Property(prop => prop.LastName).IsRequired();
            entityBuilder.Property(prop => prop.UserName).IsRequired();
            entityBuilder.Property(prop => prop.Password).IsRequired();
            entityBuilder.HasMany(entity => entity.Bookings).WithOne(entity => entity.User).HasForeignKey(fk => fk.UserId);
        }
    }
}
