using TestMydiator.Models;

namespace TestMydiator.DataAccess;

public interface IDataService
{
    Task<List<TModel>> GetAll<TModel>() where TModel : IModel;

    Task<TModel> GetById<TModel>(int id) where TModel : IModel, new();

    Task<TModel> Create<TModel>(TModel model) where TModel : IModel;

    Task<TModel> Update<TModel>(TModel model) where TModel : IModel;

    Task<bool> Delete<TModel>(int id) where TModel : IModel;

}
