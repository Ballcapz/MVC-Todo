using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoMvc.Models
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>> GetAll();
        Task Add(TodoItem todo);
        Task Remove(Guid id);
        Task<TodoItem> Find(Guid id);
        Task Update(TodoItem todo);
    }
}
