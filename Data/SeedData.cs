using Microsoft.EntityFrameworkCore;
using MyBlog.Entities;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace MyBlog.Data
{
    public class SeedData
    {
        public static async Task SeedUsers(DataContext context)
        {
            if(await context.Posts.AnyAsync())
            {
                return;
            }

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");

            var users = JsonSerializer.Deserialize<List<Post>>(userData);

            if (users == null)
            {
                return;
            }

            foreach (var user in users)
            {

                await context.Posts.AddAsync(user);
            }

            await context.SaveChangesAsync();



        }
    }
}
