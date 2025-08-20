using AutoMapper;
using Backend.Dtos;
using Backend.Models;
using Backend.Repositories;
using Backend.Services;

namespace SkillMatchApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateUserAsync(UserDto userDto, string password)
        {
            var user = _mapper.Map<User>(userDto);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
            await _repo.AddAsync(user);
            return _mapper.Map<UserDto>(user);
        }
    }
}

