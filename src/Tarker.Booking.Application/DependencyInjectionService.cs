using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Tarker.Booking.Application.Configuration;
using Tarker.Booking.Application.Database.Booking.Commands.CreateBooking;
using Tarker.Booking.Application.Database.Booking.Commands.DeleteBooking;
using Tarker.Booking.Application.Database.Booking.Commands.UpdateBooking;
using Tarker.Booking.Application.Database.Booking.Queries.GetAllBookings;
using Tarker.Booking.Application.Database.Booking.Queries.GetBookingByDocNumber;
using Tarker.Booking.Application.Database.Booking.Queries.GetBookingByType;
using Tarker.Booking.Application.Database.Customer.Commnads.CreateCustomer;
using Tarker.Booking.Application.Database.Customer.Commnads.DeleteCustomer;
using Tarker.Booking.Application.Database.Customer.Commnads.UpdateCustomer;
using Tarker.Booking.Application.Database.Customer.Queries.GetAllCustomers;
using Tarker.Booking.Application.Database.Customer.Queries.GetCustomerByDocNumber;
using Tarker.Booking.Application.Database.User.Commands.CreateUser;
using Tarker.Booking.Application.Database.User.Commands.DeleteUser;
using Tarker.Booking.Application.Database.User.Commands.UpdateUser;
using Tarker.Booking.Application.Database.User.Commands.UpdateUserPassword;
using Tarker.Booking.Application.Database.User.Queries.GetAllUsers;
using Tarker.Booking.Application.Database.User.Queries.GetUser;
using Tarker.Booking.Application.Database.User.Queries.GetUserByUsernameAndPasword;
using Tarker.Booking.Application.Validators.Booking;
using Tarker.Booking.Application.Validators.Customer;
using Tarker.Booking.Application.Validators.User;

namespace Tarker.Booking.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });
            # region User
            services.AddSingleton(mapper.CreateMapper());
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<IUpdateUserPassword, UpdateUserPassword>();
            services.AddTransient<IGetAllUsersQuery, GetAllUsersQuery>();
            services.AddTransient<IGetUserByIdQuery, GetUserByIdQuery>();
            services.AddTransient<IGetUserByUsernameAndPasswordQuery, GetUserByUsernameAndPasswordQuery>();
            #endregion

            #region Customer
            services.AddTransient<ICreateCustomerCommand, CreateCustomerCommand>();
            services.AddTransient<IUpdateCustomerCommand, UpdateCustomerCommand>();
            services.AddTransient<IDeleteCustomerCommand, DeleteCustomerCommand>();
            services.AddTransient<IGetAllCustomersQuery, GetAllCustomersQuery>();
            services.AddTransient<IGetCustomerByDocNumberQuery, GetCustomerByDocNumberQuery>();
            services.AddTransient<IGetCustomerByIdQuery, GetCustomerByIdQuery>();
            #endregion

            #region Booking
            services.AddTransient<ICreateBookingCommand, CreateBookingCommand>();
            services.AddTransient<IDeleteBookingCommand, DeleteBookingCommand>();
            services.AddTransient<IUpdateBookingCommand, UpdateBookingCommand>();
            services.AddTransient<IGetAllBookingsQuery, GetAllBookingsQuery>();
            services.AddTransient<IGetBookingByDocNumberQuery, GetBookingByDocNumberQuery>();
            services.AddTransient<IGetBookingByTypeQuery, GetBookingByTypeQuery>();
            #endregion

            #region validator
            services.AddScoped<IValidator<CreateUserModel>, CreateUserValidator>();
            services.AddScoped<IValidator<UpdateUserPasswordModel>, UpdateUserPasswordValidator>();
            services.AddScoped<IValidator<UpdateUserModel>, UpdateUserValidator>();


            services.AddScoped<IValidator<UpdateCustomerModel>, UpdateCustomerValidator>();
            services.AddScoped<IValidator<CreateCustomerModel>, CreateCustomerValidator>();

            services.AddScoped<IValidator<CreateBookingModel>, CreateBookingValidator>();
            #endregion
            return services;
        }
    }
}
