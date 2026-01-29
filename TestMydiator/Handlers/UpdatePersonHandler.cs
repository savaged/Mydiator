using Mydiator;
using TestMydiator.Commands;
using TestMydiator.DataAccess;
using TestMydiator.Models;

namespace TestMydiator.Handlers;

public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, PersonModel>
{
    private readonly IDataService _dataService;

    public UpdatePersonHandler(IDataService dataService)
    {
        ArgumentNullException.ThrowIfNull(dataService);
        _dataService = dataService;
    }

    public async Task<PersonModel> Handle(UpdatePersonCommand request, CancellationToken cancellationToken) =>
        await _dataService.Update(new PersonModel(request.Id, request.Firstname, request.Lastname));
}
