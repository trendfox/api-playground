using ApiPlayground.P02.PersonApi.Models;
using Dto = ApiPlayground.P02.PersonApi.Models.DTOs;
using ApiPlayground.P02.PersonApi.Services.Interfaces;

namespace ApiPlayground.P02.PersonApi.Services;

public class PersonMapper
    : IMapper<Person, Dto.Person>
{
    public Person Convert(Dto.Person other)
    {
        return new Person
        {
            Id = other.Id,
            FirstName = other.FirstName,
            LastName = other.LastName,
            Gender =  other.Gender,
        };
    }

    public Dto.Person Convert(Person other)
    {
        return new Dto.Person
        {
            Id = other.Id,
            FirstName = other.FirstName,
            LastName = other.LastName,
            Gender = other.Gender,
        };
    }
}
