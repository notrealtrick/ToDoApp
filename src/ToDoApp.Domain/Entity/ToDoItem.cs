using System;
using Volo.Abp.Domain.Entities;

namespace ToDoApp
{
    public class TodoItem : Entity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreationTime { get; set; }

        // Constructor
        public TodoItem()
        {
            CreationTime = DateTime.Now;
        }
    }
}