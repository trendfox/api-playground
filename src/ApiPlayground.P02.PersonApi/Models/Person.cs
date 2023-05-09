namespace ApiPlayground.P02.PersonApi.Models;

public class Person
    : IIdentifyable
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public Gender? Gender { get; set; }
}
