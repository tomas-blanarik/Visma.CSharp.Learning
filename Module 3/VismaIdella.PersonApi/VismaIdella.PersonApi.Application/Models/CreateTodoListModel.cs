using System.ComponentModel.DataAnnotations;
using VismaIdella.PersonApi.Application.Domain;

namespace VismaIdella.PersonApi.Application.Models
{
    public class CreateTodoListModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int PersonId { get; set; }

        public TodoList ToDomain()
        {
            return new TodoList
            {
                Name = Name,
                PersonId = PersonId
            };
        }
    }
}
