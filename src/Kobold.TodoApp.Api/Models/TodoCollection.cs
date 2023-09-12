using System;
using System.Collections.Generic;

namespace Kobold.TodoApp.Api.Models
{
    public class TodoCollection
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Todo> Todos { get; set; } = new List<Todo>();

        public TodoCollection()
        {
            Id = Guid.NewGuid();
        }
    }
}
