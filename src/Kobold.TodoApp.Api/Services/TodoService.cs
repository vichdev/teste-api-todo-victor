using System;
using System.Collections.Generic;
using System.Linq;
using Kobold.TodoApp.Api.Models;

namespace Kobold.TodoApp.Api.Services
{

    public class TodoService
    {

        private static List<Todo> Todos = new List<Todo>();
        private static List<TodoCollection> TodoCollections = new List<TodoCollection>();

        public TodoCollection GetTodoCollectionById(Guid todoCollectionId)
        {

            var todoCollections = TodoCollections.FirstOrDefault(collection => collection.Id == todoCollectionId);

           return todoCollections == null ? throw new ApplicationException("Esta coleção de tarefas não existe.") :  todoCollections;
        }

        public List<TodoCollection> GetTodosCollection()
        {
            return TodoCollections;
        }

        public void CreateTodoCollection(TodoCollectionViewModel todoCollection)
        {
           
                var collection = new TodoCollection { Name = todoCollection.Name, Todos = new List<Todo>() };

                TodoCollections.Add(collection);
            

        }

        public void AddTodoToCollection(Guid todoCollectionId, Guid todoId)
        {
            var todoCollection = GetTodoCollectionById(todoCollectionId);
            var todo = Todos.FirstOrDefault(todo => todo.Id == todoId);

            if (todoCollection != null & todo != null)
            {
                todoCollection.Todos.Add(todo);
            } else
            {
                throw new ApplicationException("Não foi possível adicionar a tarefa nessa coleção.");

            }
        }

        public void RemoveTodoFromCollection(Guid todoCollectionId, Guid todoId) 
        {
            var todoCollection = GetTodoCollectionById(todoCollectionId);
            var todo = todoCollection.Todos.FirstOrDefault(todo => todo.Id == todoId);


            if (todoCollection != null & todo != null)
            {
                todoCollection.Todos.Remove(todo);
            }
            else
            {
                throw new ApplicationException("Não foi possível remover a tarefa desta coleção.");

            }
        }

        public void UpdateTodoFromCollection(Guid todoCollectionId, Todo todoViewModel)
        {
            var todoCollection = GetTodoCollectionById(todoCollectionId);
            var todo = todoCollection.Todos.FirstOrDefault(todo => todo.Id == todoViewModel.Id);

            if (todoCollection != null & todo != null)
            {
                todo.Description = todoViewModel.Description;
                todo.Done = todoViewModel.Done;
            } else
            {
                throw new ApplicationException("Não foi possível remover a tarefa desta coleção.");
            }
        }

        public void CreateTodo(TodoViewModel todoViewModel)
        {
            var todo = new Todo
            {
                DataCriacao = DateTime.Now,
                Description = todoViewModel.Description,
                Done = todoViewModel.Done,
            };

            Todos.Add(todo);
        }

        public void UpdateTodo(Guid id, TodoViewModel todovm)
        {
            var todo = Todos.Single(todo => todo.Id == id);
            if (todo != null)
            {
                todo.Done = todovm.Done;
            } else
            {
                throw new ApplicationException("Não foi possível atualizar a tarefa.");

            }


        }

        public Todo GetTodoById(Guid id)
        {
            var todosById = Todos.Single(todo => todo.Id == id);
            if(todosById != null)
            {
                return todosById;
            } else
            {
                throw new ApplicationException("Não foi possível encontrar esta coleção.");

            }
        }

        public List<Todo> GetTodos()
        {
            return Todos;
        }

        public void RemoveTodo(Guid id)
        {
            var index = Todos.FindIndex(todo => todo.Id == id);
            if (index == -1)
            {

            Todos.RemoveAt(index);
            } else
            {
                throw new ApplicationException("Não foi possível remover esta tarefa.");

            }
        }

    }
}
