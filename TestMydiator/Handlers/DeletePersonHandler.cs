using Mydiator;
using TestMydiator.Commands;
using TestMydiator.DataAccess;
using TestMydiator.Models;

namespace TestMydiator.Handlers;

public class DeletePersonHandler : IRequestHandler<DeletePersonCommand, bool>
{
    private readonly IDataService _dataService;

    public DeletePersonHandler(IDataService dataService)
    {
        ArgumentNullException.ThrowIfNull(dataService);
        _dataService = dataService;
    }

    public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken) =>
        await _dataService.Delete<PersonModel>(request.Id);
}
