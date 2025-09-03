namespace Backend.Models.Project;

public class Project
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
}