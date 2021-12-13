using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VismaIdella.PersonApi.Application.Dtos;

namespace VismaIdella.PersonApi.Application.Domain
{
    public class TodoList
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }

        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public ICollection<TodoListItem> Items { get; set; } = new List<TodoListItem>();

        public TodoListDto ToDto(bool includeItems = true)
        {
            return new TodoListDto
            {
                Id = Id,
                Name = Name,
                DateCreated = DateCreated,
                Items = includeItems ? Items.Select(x => x.ToDto()).ToList() : null
            };
        }

        public TodoListLightDto ToLightDto() => ToDto(false);
    }
}
