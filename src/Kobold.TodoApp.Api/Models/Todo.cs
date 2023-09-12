using System;

namespace Kobold.TodoApp.Api.Models
{
    public class Todo
    {

        public Guid Id { get; set; }

        public DateTime DataCriacao { get; set; }

        public bool Done { get; set; }

        public string Description { get; set; }

        public Todo()
        {
            Id = Guid.NewGuid();
        }
    }

  
}
