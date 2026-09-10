namespace waraPT_backend.Dtos;

public class WorkerRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Dni { get; set; } = string.Empty;
    public int Age { get; set; }
}