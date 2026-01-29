using Mydiator;
using TestMydiator.Commands;
using TestMydiator.DataAccess;
using TestMydiator.Models;

namespace TestMydiator.Handlers;

public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, PersonModel>
{
    private readonly IDataService _dataService;

    public CreatePersonHandler(IDataService dataService)
    {
        ArgumentNullException.ThrowIfNull(dataService);
        _dataService = dataService;
    }

    public async Task<PersonModel> Handle(CreatePersonCommand request, CancellationToken cancellationToken) =>
        await _dataService.Create(new PersonModel(firstname: request.Firstname, lastname: request.Lastname));
}
