using Mydiator;
using TestMydiator.Models;

namespace TestMydiator.Commands;

public record UpdatePersonCommand(int Id, string Firstname, string Lastname) : IRequest<PersonModel>;
