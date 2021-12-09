using System.ComponentModel.DataAnnotations;

namespace CSharpLearning.WebAPI.Models
{
    public class Account
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int? Amount { get; set; }
    }
}
