using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VismaIdella.PersonApi.Application.Dtos;

namespace VismaIdella.PersonApi.Application.Domain
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        public string Address { get; set; }
        public ICollection<TodoList> Lists { get; set; } = new List<TodoList>();

        public PersonDto ToDto()
        {
            return new PersonDto
            {
                Id = Id,
                Name = Name,
                Email = Email,
                Address = Address
            };
        }
    }
}
