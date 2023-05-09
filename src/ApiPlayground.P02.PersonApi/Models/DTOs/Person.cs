using System.ComponentModel.DataAnnotations;

namespace ApiPlayground.P02.PersonApi.Models.DTOs;

public class Person
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = "";

    [Required]
    public string LastName { get; set; } = "";

    public Gender? Gender { get; set; }
}
