using Backend.Models.Project;

namespace Backend.Repositories
{
    public class ProjectRepository
    {
        private static readonly List<Project> projects = new();
        public List<Project> GetAll() => projects;
        public void Add(Project project) => projects.Add(project);
    }
}
