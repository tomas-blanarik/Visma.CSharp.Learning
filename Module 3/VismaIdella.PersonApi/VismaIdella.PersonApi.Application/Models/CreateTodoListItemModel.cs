using System;
using System.ComponentModel.DataAnnotations;
using VismaIdella.PersonApi.Application.Domain;

namespace VismaIdella.PersonApi.Application.Models
{
    public class CreateTodoListItemModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }

        public TodoListItem ToDomain()
        {
            return new TodoListItem
            {
                Name = Name,
                Description = Description,
                DueDate = DueDate
            };
        }
    }
}
