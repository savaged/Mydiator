using Mydiator;
using TestMydiator.Models;

namespace TestMydiator.Commands;

public record CreatePersonCommand(string Firstname, string Lastname) : IRequest<PersonModel>;
