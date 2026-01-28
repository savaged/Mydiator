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
}
