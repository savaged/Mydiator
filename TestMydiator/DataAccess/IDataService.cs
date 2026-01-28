using TestMydiator.Models;

namespace TestMydiator.DataAccess;

public interface IDataService
{
    public List<TModel> GetAll<TModel>() where TModel : IModel;

    public TModel Create<TModel>(TModel model) where TModel : IModel;

}
