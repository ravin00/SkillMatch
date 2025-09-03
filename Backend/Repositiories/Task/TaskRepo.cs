using Backend.Models.Task;

namespace Backend.Repositories
{
    public class TaskRepository
    {
        private static readonly List<Task> tasks = new();

        public List<Task> GetAll() => tasks;

        public void Add(Task task) => tasks.Add(task);
    }
}
