using Mydiator;
using TestMydiator.DataAccess;
using TestMydiator.Models;
using TestMydiator.Queries;

namespace TestMydiator.Handlers;

public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonModel>
{
    private readonly IDataService _dataService;

    public GetPersonByIdHandler(IDataService dataService)
    {
        ArgumentNullException.ThrowIfNull(dataService);
        _dataService = dataService;
    }

    public Task<PersonModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken) =>
        Task.FromResult(_dataService.GetById<PersonModel>(request.Id));
}
