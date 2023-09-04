using Infra.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.Interfaces;
using Domain.Notifications;
using Domain.Services;
using Infra.Context;
using Infra.Repository;


namespace API.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyDbContext>();
            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomService, RoomService>();

            return services;
        }
    }
}
