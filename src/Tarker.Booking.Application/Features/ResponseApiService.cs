using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Models;

namespace Tarker.Booking.Application.Features
{
    public static class ResponseApiService
    {
        public static ResponseModel Response(int statusCode, string messaje =null, object data =null)
        {
            bool success = false;

            if(statusCode >= 200 &&  statusCode < 300) success = true;

                var result = new ResponseModel
                {
                   StatusCode = statusCode,
                   Success = success,
                   Message = messaje,
                   Data = data
                };
            return result;
        }
    }
}
