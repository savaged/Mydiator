using Mydiator;
using TestMydiator.Queries;

namespace TestMydiator;

[TestClass]
public sealed class ReadTests
{
    [TestMethodDI]
    public async Task TestGetPersonListQuery(ISender sender)
    {
        var people = await sender.Send(new GetPersonListQuery());
        Assert.IsNotNull(people);
        Assert.IsTrue(people.Count > 0);
    }

    [TestMethodDI]
    public async Task TestGetPersonByIdQuery(ISender sender)
    {
        const int id = 2;
        var person = await sender.Send(new GetPersonByIdQuery(id));
        Assert.IsNotNull(person);
        Assert.IsTrue(person.Id == id);
    }
}
