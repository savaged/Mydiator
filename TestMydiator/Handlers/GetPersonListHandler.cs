using Mydiator;
using TestMydiator.DataAccess;
using TestMydiator.Models;
using TestMydiator.Queries;

namespace TestMydiator.Handlers;

public class GetPersonListHandler : IRequestHandler<GetPersonListQuery, List<PersonModel>>
{
    private readonly IDataService _dataService;

    public GetPersonListHandler(IDataService dataService)
    {
        ArgumentNullException.ThrowIfNull(dataService);
        _dataService = dataService;
    }

    public Task<List<PersonModel>> Handle(GetPersonListQuery request, CancellationToken cancellationToken) =>
        Task.FromResult(_dataService.GetAll<PersonModel>());
}
