using Backend.Models;

namespace Backend.Repositories.Interfaces
{
    public interface IMatchRepository
    {
        Task<IEnumerable<Match>> GetAllMatchesAsync();
        Task<Match?> GetMatchByIdAsync(int id);
        Task<IEnumerable<Match>> GetMatchesByUserIdAsync(int userId);
        Task<IEnumerable<Match>> GetMatchesByJobIdAsync(int jobId);
        Task<Match> CreateMatchAsync(Match match);
        Task<Match> UpdateMatchAsync(Match match);
        Task<bool> DeleteMatchAsync(int id);
        Task<bool> MatchExistsAsync(int id);
        Task<Match?> GetMatchByUserAndJobAsync(int userId, int jobId);
        Task<IEnumerable<Match>> GetTopMatchesForUserAsync(int userId, int count = 10);
    }
}