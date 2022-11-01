using MangersWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangersWebApi
{
    public class Services
    {
        public static ServiceProvider CollectionServices = ServiceProvider();
        private static ServiceProvider ServiceProvider()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<WebApiContext>(options =>
                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MangersWebApiDb;Integrated Security=true"));
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
