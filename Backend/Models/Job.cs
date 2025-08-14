namespace Backend.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SkillsRequired { get; set; }
        public int EmployerId { get; set; }
        public User Employer { get; set; }
    }
}