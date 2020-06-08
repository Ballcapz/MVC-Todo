using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoMvc.Models;

namespace TodoMvc.Services
{
    public class TodoDbContext : DbContext, ITodoRepository
    {

        public DbSet<TodoItem> Todos { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().ToTable("Todo").HasKey(todo => todo.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Todo");
        }

        public async Task Add([Bind(nameof(TodoItem.Description))] TodoItem todo)
        {
            Todos.Add(todo);
            await SaveChangesAsync();
        }

        public async Task<TodoItem> Find(Guid id)
        {
            return await Todos.FindAsync(id);
        }

        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            return await Todos.ToListAsync();
        }

        public async Task Remove(Guid id)
        {
            var todo = await Todos.FindAsync(id);
            Todos.Remove(todo);
            await SaveChangesAsync();
        }

        public async Task Update(TodoItem todo)
        {
            TodoItem toUpdate = await Todos.FindAsync(todo.Id);
            if (toUpdate != null)
            {
                toUpdate.Description = todo.Description;
                await SaveChangesAsync();
            }
        }
    }
}
