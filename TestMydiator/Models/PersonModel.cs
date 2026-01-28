namespace TestMydiator.Models;

public class PersonModel : IModel
{
    public int Id { get; set; }
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
}
