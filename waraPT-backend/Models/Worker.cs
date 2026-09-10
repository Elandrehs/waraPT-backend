namespace WaraPTBackend.Models;

public class Worker
{
    public int WorkerId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Dni { get; set; } = string.Empty;
    public int Age { get; set; }
    public int? UserId { get; set; }
}