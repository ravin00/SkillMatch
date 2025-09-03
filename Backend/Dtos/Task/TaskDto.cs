namespace Backend.Dtos.Task
{
    public class TaskDto
    {
        public string Title { get; set; } = string.Empty;
        public string Status { get; set; } = "todo";
        public string ProjectId { get; set; } = string.Empty;
    }
}