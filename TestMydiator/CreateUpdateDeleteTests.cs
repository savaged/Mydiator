using Mydiator;
using TestMydiator.Commands;
using TestMydiator.Models;

namespace TestMydiator;

[TestClass]
public sealed class CreateUpdateDeleteTests
{
    [TestMethodDI]
    public async Task TestCreatePersonCommand(IMediator sender)
    {
        const string firstname = "Anne";
        const string lastname = "Other";
        var person = await sender.Send(new CreatePersonCommand(firstname, lastname));
        Assert.IsNotNull(person);
        Assert.AreEqual(firstname, person.Firstname);
        Assert.AreEqual(lastname, person.Lastname);
    }
}
