using TestMydiator.Models;

namespace TestMydiator.DataAccess;

public interface IDataService
{
    List<TModel> GetAll<TModel>() where TModel : IModel;

    TModel GetById<TModel>(int id) where TModel : IModel, new();

    TModel Create<TModel>(TModel model) where TModel : IModel;

}
