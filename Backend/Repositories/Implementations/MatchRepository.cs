using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Data;
using Backend.Repositories.Interfaces;

namespace Backend.Repositories.Implementations
{
    public class MatchRepository : IMatchRepository
    {
        private readonly AppDbContext _context;

        public MatchRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Match>> GetAllMatchesAsync()
        {
            return await _context.Matches
                .Include(m => m.User)
                .Include(m => m.Job)
                    .ThenInclude(j => j.Employer)
                .ToListAsync();
        }

        public async Task<Match?> GetMatchByIdAsync(int id)
        {
            return await _context.Matches
                .Include(m => m.User)
                .Include(m => m.Job)
                    .ThenInclude(j => j.Employer)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Match>> GetMatchesByUserIdAsync(int userId)
        {
            return await _context.Matches
                .Include(m => m.User)
                .Include(m => m.Job)
                    .ThenInclude(j => j.Employer)
                .Where(m => m.UserId == userId)
                .OrderByDescending(m => m.MatchPercentage)
                .ToListAsync();
        }

        public async Task<IEnumerable<Match>> GetMatchesByJobIdAsync(int jobId)
        {
            return await _context.Matches
                .Include(m => m.User)
                .Include(m => m.Job)
                    .ThenInclude(j => j.Employer)
                .Where(m => m.JobId == jobId)
                .OrderByDescending(m => m.MatchPercentage)
                .ToListAsync();
        }

        public async Task<Match> CreateMatchAsync(Match match)
        {
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();
            return match;
        }

        public async Task<Match> UpdateMatchAsync(Match match)
        {
            _context.Entry(match).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return match;
        }

        public async Task<bool> DeleteMatchAsync(int id)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match == null)
            {
                return false;
            }

            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> MatchExistsAsync(int id)
        {
            return await _context.Matches.AnyAsync(m => m.Id == id);
        }

        public async Task<Match?> GetMatchByUserAndJobAsync(int userId, int jobId)
        {
            return await _context.Matches
                .Include(m => m.User)
                .Include(m => m.Job)
                    .ThenInclude(j => j.Employer)
                .FirstOrDefaultAsync(m => m.UserId == userId && m.JobId == jobId);
        }

        public async Task<IEnumerable<Match>> GetTopMatchesForUserAsync(int userId, int count = 10)
        {
            return await _context.Matches
                .Include(m => m.User)
                .Include(m => m.Job)
                    .ThenInclude(j => j.Employer)
                .Where(m => m.UserId == userId)
                .OrderByDescending(m => m.MatchPercentage)
                .Take(count)
                .ToListAsync();
        }
    }
}
