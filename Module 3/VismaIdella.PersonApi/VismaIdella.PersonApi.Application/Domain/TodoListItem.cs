using System;
using System.ComponentModel.DataAnnotations;

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
    }
}
