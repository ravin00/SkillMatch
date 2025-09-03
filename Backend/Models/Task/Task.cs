namespace Backend.Models.Task;
public class TaskItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = string.Empty;

    public string Status { get; set; } = "todo";

    public string ProjectId { get; set; } = string.Empty;

}
