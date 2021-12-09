using System.ComponentModel.DataAnnotations;
using VismaIdella.PersonApi.Application.Domain;

namespace VismaIdella.PersonApi.Application.Models
{
    public class CreatePersonModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        public string Address { get; set; }

        public Person ToDomain()
        {
            return new Person
            {
                Name = Name,
                Address = Address,
                Email = Email
            };
        }
    }
}
