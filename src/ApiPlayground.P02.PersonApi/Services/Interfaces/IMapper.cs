namespace ApiPlayground.P02.PersonApi.Services.Interfaces;

public interface IMapper<T1, T2>
{
    T1 Convert(T2 other);
    T2 Convert(T1 other);
}
