using AutoMapper;
using Tarker.Booking.Application.Database.Booking.Commands.CreateBooking;
using Tarker.Booking.Application.Database.Booking.Commands.UpdateBooking;
using Tarker.Booking.Application.Database.Booking.Queries.GetAllBookings;
using Tarker.Booking.Application.Database.Booking.Queries.GetBookingByDocNumber;
using Tarker.Booking.Application.Database.Booking.Queries.GetBookingByType;
using Tarker.Booking.Application.Database.Customer.Commnads.CreateCustomer;
using Tarker.Booking.Application.Database.Customer.Commnads.UpdateCustomer;
using Tarker.Booking.Application.Database.Customer.Queries.GetAllCustomers;
using Tarker.Booking.Application.Database.User.Commands.CreateUser;
using Tarker.Booking.Application.Database.User.Commands.UpdateUser;
using Tarker.Booking.Application.Database.User.Queries.GetAllUsers;
using Tarker.Booking.Application.Database.User.Queries.GetUser;
using Tarker.Booking.Domain.Entities.Booking;
using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region User
            CreateMap<UserEntity, CreateUserModel>().ReverseMap();
            CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
            CreateMap<UserEntity, GetAllUsersModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByIdModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByUsernameAndPasswordModel>().ReverseMap();
            #endregion

            #region Customer
            CreateMap<CustomerEntity, CreateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, UpdateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetAllCustomersModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByIdModel>().ReverseMap();
            #endregion
            #region Booking
            CreateMap<BookingEntity, CreateBookingModel>().ReverseMap();
            CreateMap<BookingEntity, UpdateBookingModel>().ReverseMap();
            CreateMap<BookingEntity, GetAllBookingsModel>().ReverseMap();
            CreateMap<BookingEntity, GetBookingByTypeModel>().ReverseMap();
            CreateMap<BookingEntity, GetBookingByDocNumberModel>().ReverseMap();
            #endregion
        }
    }
}
