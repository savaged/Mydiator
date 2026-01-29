using TestMydiator.Models;

namespace TestMydiator.DataAccess;

public class DataService : IDataService
{
    // TODO add other model types
    private readonly List<PersonModel> _people = [];

    public DataService()
    {
        _people.Add(new PersonModel(1, "Tim", "Corey"));
        _people.Add(new PersonModel(2, "Bob", "Smith"));
        _people.Add(new PersonModel(3, "Alice", "Brown"));
        // TODO add other model types
    }

    public async Task<List<TModel>> GetAll<TModel>() where TModel : IModel
    {
        await SimulateAsync();
        // TODO change to switch pattern for other types of model
        var result = _people as List<TModel> ?? [];
        return result;
    }

    public async Task<TModel> GetById<TModel>(int id) where TModel : IModel, new()
    {
        await SimulateAsync();
        // TODO change to switch pattern for other types of model
        if (_people.FirstOrDefault(m => m.Id == id) is TModel model)
            return model;
        return new TModel();
    }

    public async Task<TModel> Create<TModel>(TModel model) where TModel : IModel
    {
        await SimulateAsync();
        // TODO change to switch pattern for other types of model
        if (model is PersonModel person)
        {
            model.Id = person.Id = _people.Count + 1;
            _people.Add(person);
        }
        return model;
    }

    public async Task<TModel> Update<TModel>(TModel model) where TModel : IModel
    {
        await SimulateAsync();
        // TODO change to switch pattern for other types of model
        var match = _people.FirstOrDefault(m => m.Id == model.Id);
        if (match is PersonModel person)
        {
            _people.Remove(match);
            _people.Add(person);
        }
        return model;
    }

    public async Task<bool> Delete<TModel>(int id) where TModel : IModel
    {
        await SimulateAsync();
        var match = _people.FirstOrDefault(m => m.Id == id);
        if (match is PersonModel person)
            _people.Remove(match);
        return true;
    }

    private static async Task SimulateAsync() => await Task.CompletedTask;

}
