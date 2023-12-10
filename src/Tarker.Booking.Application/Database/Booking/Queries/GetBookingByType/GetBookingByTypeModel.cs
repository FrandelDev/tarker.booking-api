using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.Database.Booking.Queries.GetBookingByType
{
    public class GetBookingByTypeModel
    {
        public string Code { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Type { get; set; }
        public string FullName { get; set; }
        public string DocumentNumber { get; set; }
    }
}
