using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApp;
using ToDoApp;
using TodoApp.Application;

namespace TodoApp.HttpApi.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoItemAppService _todoItemAppService;

        public TodoController(TodoItemAppService todoItemAppService)
        {
            _todoItemAppService = todoItemAppService;
        }

        [HttpGet]
        public ActionResult<List<TodoItem>> Get()
        {
            return _todoItemAppService.GetList();
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(Guid id)
        {
            var todoItem = _todoItemAppService.Get(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return todoItem;
        }

        [HttpPost]
        public ActionResult<TodoItem> Post(TodoItem todoItem)
        {
            return _todoItemAppService.Create(todoItem);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }
            _todoItemAppService.Update(todoItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _todoItemAppService.Delete(id);
            return NoContent();
        }
    }
}