using MangersDAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MangersDAL
{
    public class MangersContext : IdentityDbContext<User>
    {
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Manga> Mangas { get; set; }
        public DbSet<Page> Pages { get; set; }
        public MangersContext()
        {

        }
        public MangersContext(DbContextOptions<MangersContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MangersDb;Integrated Security=true");
            }
        }
    }
}
