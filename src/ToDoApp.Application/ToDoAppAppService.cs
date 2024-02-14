using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoApp;
using ToDoApp.Localization;
using Volo.Abp.Application.Services;


namespace TodoApp.Application
{
    public class TodoItemAppService
    {
        private readonly List<TodoItem> _todoItems;

        public TodoItemAppService()
        {
            // Örnek veri oluşturmak için
            _todoItems = new List<TodoItem>
            {
                new TodoItem { Id = Guid.NewGuid(), Title = "İlk görev", Content = "Bu bir örnek görevdir.", Deadline = DateTime.Now.AddDays(3) },
                new TodoItem { Id = Guid.NewGuid(), Title = "İkinci görev", Content = "Bu da bir örnek görevdir.", Deadline = DateTime.Now.AddDays(5) }
            };
        }

        public List<TodoItem> GetList()
        {
            return _todoItems;
        }

        public TodoItem Get(Guid id)
        {
            return _todoItems.FirstOrDefault(t => t.Id == id);
        }   

        public TodoItem Create(TodoItem todoItem)
        {
            todoItem.Id = Guid.NewGuid();
            _todoItems.Add(todoItem);
            return todoItem;
        }

        public void Update(TodoItem todoItem)
        {
            var existingTodoItem = _todoItems.FirstOrDefault(t => t.Id == todoItem.Id);
            if (existingTodoItem != null)
            {
                existingTodoItem.Title = todoItem.Title;
                existingTodoItem.Content = todoItem.Content;
                existingTodoItem.Deadline = todoItem.Deadline;
            }
        }

        public void Delete(Guid id)
        {
            var existingTodoItem = _todoItems.FirstOrDefault(t => t.Id == id);
            if (existingTodoItem != null)
            {
                _todoItems.Remove(existingTodoItem);
            }
        }
    }
}