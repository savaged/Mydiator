using Mydiator;
using TestMydiator.Models;

namespace TestMydiator.Queries;

public record GetPersonListQuery() : IRequest<List<PersonModel>>;
