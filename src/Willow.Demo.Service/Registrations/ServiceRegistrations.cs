namespace Willow.Demo.Service.Registrations
{
    using Data;
    using Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Services;

    public static class ServiceRegistrations
    {
        public static IServiceCollection AddServiceRegistrations(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                 .AddTransient<IRxJobRepository, RxJobRepository>()
                 .AddTransient<IRxRoomTypeRepository, RxRoomTypeRepository>()
                 .AddTransient<IJobService, JobService>()
                 .AddTransient<IFloorService, FloorService>()
                 .AddDbContext<DemoContext>(options =>
                 {
                     options.UseSqlServer(configuration.GetConnectionString("WillowDemoContext"));
                 });
        }
    }
}
