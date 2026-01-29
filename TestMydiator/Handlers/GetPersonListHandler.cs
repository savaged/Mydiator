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

    public async Task<List<PersonModel>> Handle(GetPersonListQuery request, CancellationToken cancellationToken) =>
        await _dataService.GetAll<PersonModel>();
}
