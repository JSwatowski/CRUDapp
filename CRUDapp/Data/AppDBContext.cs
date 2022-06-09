using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDapp.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlite("Data Source=./Data/AppDbB.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Post[] postsToSeed = new Post[6];
            for (int i = 1; i <= 6; i++)
            {
                postsToSeed[i-1] = new Post
                {
                    PostId = i,
                    UserName = "User" + i,
                    Text = "Just some text" + i
                };
            }

            modelBuilder.Entity<Post>().HasData(postsToSeed);
        }
        
    }
}
