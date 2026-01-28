using TestMydiator.Models;

namespace TestMydiator.DataAccess;

public class DataService : IDataService
{
    // TODO add other model types
    private readonly List<PersonModel> _people = new();

    public DataService()
    {
        _people.Add(new PersonModel { Id = 1, Firstname = "Tim", Lastname = "Corey" });
        _people.Add(new PersonModel { Id = 2, Firstname = "Bob", Lastname = "Smith" });
        _people.Add(new PersonModel { Id = 3, Firstname = "Alice", Lastname = "Brown" });
        // TODO add other model types
    }

    public List<TModel> GetAll<TModel>() where TModel : IModel
    {
        // TODO change to switch pattern for other types of model
        return _people as List<TModel> ?? new();
    }

    public TModel Create<TModel>(TModel model) where TModel : IModel
    {
        // TODO change to switch pattern for other types of model
        if (model is PersonModel person)
        {
            person.Id = _people.Count + 1;
            _people.Add(person);
        }
        return model;
    }

}
