using FinalProject.Application.Abstractions.Repositories;
using FinalProject.Application.Abstractions.Services;
using FinalProject.Application.Services;
using FinalProject.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProject.Application
{
    /// <summary>
    /// Класс регистрации зависимостей в слое Application.
    /// </summary>
    public static class Bootstrapper
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IEntitieService<User>, UserService>();
            services.AddScoped<IEntitieService<Operator>, OperatorService>();
            services.AddScoped<IEntitieService<Payment>, PaymentService>();
            services.AddScoped<IEntitieService<Reservation>, ReservationService>();
            services.AddScoped<IEntitieService<Ticket>, TicketService>();
            services.AddScoped<IEntitieService<TicketData>, TicketDataService>();

            return services;
        }
    }
}
