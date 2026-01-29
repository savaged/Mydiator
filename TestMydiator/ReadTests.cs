using Mydiator;
using TestMydiator.Queries;

namespace TestMydiator;

[TestClass]
public sealed class ReadTests
{
    [TestMethodDI]
    public async Task TestGetPersonListQuery(IMediator mediator)
    {
        var people = await mediator.Send(new GetPersonListQuery());
        Assert.IsNotNull(people);
        Assert.IsTrue(people.Count > 0);
    }

    [TestMethodDI]
    public async Task TestGetPersonByIdQuery(IMediator mediator)
    {
        const int id = 2;
        var person = await mediator.Send(new GetPersonByIdQuery(id));
        Assert.IsNotNull(person);
        Assert.AreEqual(id, person.Id);
    }

    public TestContext? TestContext { get; set; }
}
