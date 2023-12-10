using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Persistence.Configuration
{
    internal class CustomerConfiguration
    {
        public CustomerConfiguration(EntityTypeBuilder<CustomerEntity> entityBuilder)
        {
            entityBuilder.HasKey(e => e.CustomerId);
            entityBuilder.Property(prop => prop.FullName).IsRequired();
            entityBuilder.Property(prop => prop.DocumentNumber).IsRequired();
            entityBuilder.HasMany(entity => entity.Bookings).WithOne(entity => entity.Customer).HasForeignKey(fk => fk.CustomerId);
        }
    }
}
