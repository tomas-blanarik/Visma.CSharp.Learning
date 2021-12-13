using System;

namespace VismaIdella.PersonApi.Application.Dtos
{
    public class TodoListLightDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
