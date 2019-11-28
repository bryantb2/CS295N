using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityWebsite.Respositories
{
    public class AppDbContext : DbContext
    {
        // Class sets up a connection with the DB and maps models to tables
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
