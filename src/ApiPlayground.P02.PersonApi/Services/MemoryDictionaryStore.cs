using ApiPlayground.P02.PersonApi.Models;
using ApiPlayground.P02.PersonApi.Services.Interfaces;

namespace ApiPlayground.P02.PersonApi.Services;

public class MemoryDictionaryStore<TModel>
    : IStore<TModel>
    where TModel : IIdentifyable
{
    private int _nextId = 1;
    private Dictionary<int, TModel> _store = new();

    public int Create(TModel model)
    {
        var id = _nextId++;

        _store.Add(id, model);
        model.Id = id;

        return id;
    }

    public void Delete(int id)
    {
        _store.Remove(id);
    }

    public TModel[] GetAll()
    {
        return _store
            .Select(kvp => kvp.Value)
            .ToArray();
    }

    public TModel Read(int id)
    {
        return _store[id];
    }

    public void Write(TModel model)
    {
        _store[model.Id] = model;
    }
}
