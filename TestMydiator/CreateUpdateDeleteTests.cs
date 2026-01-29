using Mydiator;
using TestMydiator.Commands;

namespace TestMydiator;

[TestClass]
public sealed class CreateUpdateDeleteTests
{
    [TestMethodDI]
    public async Task TestCreatePersonCommand(IMediator mediator)
    {
        const string firstname = "Anne";
        const string lastname = "Other";
        var person = await mediator.Send(new CreatePersonCommand(firstname, lastname));
        Assert.IsNotNull(person);
        Assert.AreEqual(firstname, person.Firstname);
        Assert.AreEqual(lastname, person.Lastname);
        Assert.IsTrue(person.Id > 0);
    }

    [TestMethodDI]
    public async Task TestUpdatePersonCommand(IMediator mediator)
    {
        const string lastname = "Married";
        var person = await mediator.Send(new UpdatePersonCommand(3, "Alice", lastname));
        Assert.IsNotNull(person);
        Assert.AreEqual(lastname, person.Lastname);
    }

    [TestMethodDI]
    public async Task TestDeletePersonCommand(IMediator mediator)
    {
        var result = await mediator.Send(new DeletePersonCommand(1));
        Assert.IsTrue(result);
    }

    public TestContext? TestContext { get; set; }
}
