using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Session6.Attributes;

namespace Session6
{
    [Author("Tomas", Description = "This is my first class")]
    [Author("Tomas 1", Description = "This is my first class")]
    [Author("Tomas 2", Description = "This is my first class")]
    class FirstClass
    {
        [JsonProperty("prop")]
        [Required]
        [StringLength(10)]
        public string Property { get; set; }
    }

    [Author("Boris")]
    class SecondClass
    {

    }

    [Author("Boris Dog")]
    class ThirdClass
    {

    }
}
