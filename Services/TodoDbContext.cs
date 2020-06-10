using Microsoft.EntityFrameworkCore;
using TodoMvc.Models;

namespace TodoMvc.Services
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
            
        }

        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().ToTable("Todos").HasKey(todo => todo.Id);
        }


    }
}
