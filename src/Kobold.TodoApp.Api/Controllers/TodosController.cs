using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kobold.TodoApp.Api.Models;
using Kobold.TodoApp.Api.Services;


namespace Kobold.TodoApp.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {

        private readonly TodoService _todoService;
        private readonly ILogger<TodosController> _logger;



        public TodosController(ILogger<TodosController> logger)
        {
            _logger = logger;
            _todoService = new TodoService();
        }

        [HttpPost("collection")]
        public IActionResult CreateCollection([FromBody] TodoCollectionViewModel todoCollectionViewModel)
        {
          
            _todoService.CreateTodoCollection(todoCollectionViewModel);

            return Ok("Coleção de tarefas criada com sucesso.");
     
        }


        [HttpGet("collection")]
        public List<TodoCollection> GetCollection()
        {
            return _todoService.GetTodosCollection();
        }

        [HttpGet("collection/{id}")]
        public void GetCollectionById([FromRoute] Guid id)
        { 
       
            _todoService.GetTodoCollectionById(id);

        }

        [HttpPost("collection/addTodo")]
        public void AddTodoToCollection([FromBody] TodoCollectionViewModel todoCollectionViewModel)
        {
          
            _todoService.AddTodoToCollection(todoCollectionViewModel.Id, todoCollectionViewModel.Todo.Id);
             
        }

        [HttpDelete("collection/removeTodo")]
        public void RemoveTodoFromCollection([FromBody] TodoCollectionViewModel todoCollectionViewModel)
        {
            _todoService.RemoveTodoFromCollection(todoCollectionViewModel.Id, todoCollectionViewModel.Todo.Id);
        }

        [HttpPut("collection/updateTodo")]
        public void UpdateTodoFromCollection([FromBody] TodoCollectionViewModel todoCollectionViewModel)
        {
            _todoService.UpdateTodoFromCollection(todoCollectionViewModel.Id, todoCollectionViewModel.Todo);
        }

        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return _todoService.GetTodos();
        }

        [HttpPost]
        public void Create([FromBody] TodoViewModel todovm)
        {
            _todoService.CreateTodo(todovm);
        }

        [HttpPut("{id}")]
        public void Update([FromRoute] Guid id, [FromBody] TodoViewModel todovm)
        {
            _todoService.UpdateTodo(id, todovm);
        }

        [HttpGet("{id}")]
        public Todo Get([FromRoute] Guid id)
        {
            return _todoService.GetTodoById(id);
        }

        [HttpDelete("{id}")]
        public void Remove([FromRoute] Guid id)
        {
            _todoService.RemoveTodo(id);
        }

    }
}
