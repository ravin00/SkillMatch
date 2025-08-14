namespace Backend.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public double MatchPercentage { get; set; }
    }
}
