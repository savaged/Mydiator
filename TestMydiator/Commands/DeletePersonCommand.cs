using Mydiator;

namespace TestMydiator.Commands;

public record DeletePersonCommand(int Id) : IRequest<bool>;
