using ApiPlayground.P02.PersonApi.Models;

namespace ApiPlayground.P02.PersonApi.Services.Interfaces;

public interface IStore<TModel>
    where TModel : IIdentifyable
{
    TModel[] GetAll();
    TModel Read(int id);
    void Write(TModel model);
    int Create(TModel model);
    void Delete(int id);
}
