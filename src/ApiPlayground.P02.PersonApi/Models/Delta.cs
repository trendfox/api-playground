using System.Reflection;

namespace ApiPlayground.P02.PersonApi.Models;

public class Delta<TModel>
    : List<DeltaOperation>
    where TModel : class
{
    private readonly PropertyInfo[] _modelProperties = typeof(TModel).GetProperties();

    public void Apply(TModel target)
    {
        foreach (var op in this)
        {
            var property = _modelProperties
                .Where(mp => mp.Name.Equals(op.Field, StringComparison.OrdinalIgnoreCase))
                .SingleOrDefault();

            if (property is null)
                throw new InvalidOperationException($"Property \"{op.Field}\" does not exist.");

            switch (op.Operation)
            {
                case "replace":
                    property.SetValue(target, op.Value);
                    break;

                case "delete":
                    property.SetValue(target, null);
                    break;

                default:
                    throw new InvalidOperationException($"Operation \"{op.Operation}\" is not supported.");
            }
        }
    }
}
