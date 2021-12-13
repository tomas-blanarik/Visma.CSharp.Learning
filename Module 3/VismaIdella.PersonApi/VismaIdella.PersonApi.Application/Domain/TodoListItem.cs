using System;
using System.ComponentModel.DataAnnotations;
using VismaIdella.PersonApi.Application.Dtos;

namespace VismaIdella.PersonApi.Application.Domain
{
    public class TodoListItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }

        [Required]
        public int TodoListId { get; set; }
        public TodoList TodoList { get; set; }

        public TodoListItemDto ToDto()
        {
            return new TodoListItemDto
            {
                Id = Id,
                Name = Name,
                Description = Description,
                DueDate = DueDate
            };
        }
    }
}
