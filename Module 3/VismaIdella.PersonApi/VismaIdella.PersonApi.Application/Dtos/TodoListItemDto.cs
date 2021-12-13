using System;

namespace VismaIdella.PersonApi.Application.Dtos
{
    public class TodoListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
