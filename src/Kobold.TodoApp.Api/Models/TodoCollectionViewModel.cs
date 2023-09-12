using System;

namespace Kobold.TodoApp.Api.Models
{
    public class TodoCollectionViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Todo Todo { get; set; }
    }
}
