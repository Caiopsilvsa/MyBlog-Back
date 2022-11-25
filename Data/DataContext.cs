using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MyBlog.Entities;

namespace MyBlog.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DataContext(DbContextOptions opt):base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
        }

    }

   
}
