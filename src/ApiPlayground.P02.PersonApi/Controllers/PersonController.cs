using ApiPlayground.P02.PersonApi.Models;
using Dto = ApiPlayground.P02.PersonApi.Models.DTOs;
using ApiPlayground.P02.PersonApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiPlayground.P02.PersonApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PersonController
    : ControllerBase
{
    private readonly IStore<Person> _store;
    private readonly IMapper<Person, Dto.Person> _mapper;

    public PersonController(IStore<Person> store, IMapper<Person, Dto.Person> mapper)
    {
        _store = store;
        _mapper = mapper;
    }

    [HttpGet("generate-demo-data")]
    public void CreateDemoData()
    {
        var people = new[]
        {
            ("Maxime", "Muster"),
            ("Fred", "Rheinold"),
            ("Irma", "Flux"),
        };

        foreach (var p in people)
        {
            _store.Create(new Person
            {
                FirstName = p.Item1,
                LastName = p.Item2,
            });
        }
    }

    [HttpGet]
    public Dto.Person[] Get()
    {
        return _store
            .GetAll()
            .Select(p => _mapper.Convert(p))
            .ToArray();
    }

    [HttpGet("{id}")]
    public Dto.Person Get(int id)
    {
        return _mapper.Convert(_store
            .Read(id));
    }

    [HttpPost]
    public int Post(Dto.Person personDto)
    {
        var person = _mapper.Convert(personDto);
        return _store.Create(person);
    }

    [HttpPatch("{id}")]
    public void Patch(int id, Delta<Person> changes)
    {
        var model = _store.Read(id);
        changes.Apply(model);
        _store.Write(model);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _store.Delete(id);
    }
}
