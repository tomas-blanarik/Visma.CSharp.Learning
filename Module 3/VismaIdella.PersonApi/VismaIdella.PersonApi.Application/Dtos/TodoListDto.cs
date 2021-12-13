using System.Collections.Generic;

namespace VismaIdella.PersonApi.Application.Dtos
{
    public class TodoListDto : TodoListLightDto
    {
        public IEnumerable<TodoListItemDto> Items { get; set; }
    }
}
