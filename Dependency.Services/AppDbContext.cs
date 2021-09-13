using Dependency.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dependency.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Team> Teams { get; set; }
    }
}