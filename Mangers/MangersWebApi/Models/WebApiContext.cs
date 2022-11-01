using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangersWebApi.Models
{
    public class WebApiContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }
        public WebApiContext(DbContextOptions<WebApiContext> options)
            : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MangersWebApiDb;Integrated Security=true");
            }
        }
    }
}
