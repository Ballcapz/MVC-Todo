using System.Collections.Generic;

namespace TodoMvc.Models
{
    public class TodoViewModel
    {
        public IEnumerable<TodoItem> Items { get; set; }
    }
}
