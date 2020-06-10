using Microsoft.EntityFrameworkCore;
using TodoMvc.Models;

namespace TodoMvc.Services
{
    public class TodoDbContext : DbContext
    {

        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().ToTable("Todo").HasKey(todo => todo.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Todo");
        }

    }
}
