using Mydiator;
using TestMydiator.Commands;
using TestMydiator.DataAccess;
using TestMydiator.Models;
using TestMydiator.Queries;

namespace TestMydiator.Handlers;

public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, PersonModel>
{
    private readonly IDataService _dataService;

    public CreatePersonHandler(IDataService dataService)
    {
        ArgumentNullException.ThrowIfNull(dataService);
        _dataService = dataService;
    }

    public Task<PersonModel> Handle(CreatePersonCommand request, CancellationToken cancellationToken) =>
        Task.FromResult(_dataService.Create<PersonModel>(
            new PersonModel
            {
                Firstname = request.Firstname,
                Lastname = request.Lastname
            }));
}
