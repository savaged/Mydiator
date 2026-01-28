using Mydiator;
using TestMydiator.Models;

namespace TestMydiator.Queries;

public record GetPersonByIdQuery(int Id) : IRequest<PersonModel>;
