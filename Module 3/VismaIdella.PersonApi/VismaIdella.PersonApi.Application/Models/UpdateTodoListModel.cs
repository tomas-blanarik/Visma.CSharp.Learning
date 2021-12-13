using System.ComponentModel.DataAnnotations;
using VismaIdella.PersonApi.Application.Domain;

namespace VismaIdella.PersonApi.Application.Models
{
    public class UpdateTodoListModel
    {
        [Required]
        public string Name { get; set; }

        public TodoList ToDomain()
        {
            return new TodoList
            {
                Name = Name
            };
        }
    }
}
