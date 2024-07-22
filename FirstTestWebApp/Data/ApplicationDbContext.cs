using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using FirstTestWebApp.Models;

namespace FirstTestWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {

        // creating constructor  public ApplicationDbContext with parameters 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  // passing the parameters to base class
        {

        }


        public DbSet<Categories> C_Categories { get; set; }  // creating table

    }

   
}
