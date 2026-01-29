namespace TestMydiator.Models;

public struct PersonModel(int id = 0, string firstname = "", string lastname = "") : IModel
{
    public int Id { get; set; } = id;
    public string Firstname { get; } = firstname;
    public string Lastname { get; } = lastname;
}
