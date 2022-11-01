using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MangersDAL
{
    public static class Services
    {
        public static ServiceProvider CollectionServices = ServiceProvider();
        private static ServiceProvider ServiceProvider()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<MangersContext>(options =>
                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MangersDb;Integrated Security=true"));
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
