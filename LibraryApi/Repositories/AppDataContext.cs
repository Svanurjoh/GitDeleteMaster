using LibraryApi.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Repositories
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options)
            :  base(options)
        {

        }

        public DbSet<Book> Books {get; set;}
        public DbSet<Loans> Loans {get; set;}
        public DbSet<Person> Persons {get; set;}
    }
}