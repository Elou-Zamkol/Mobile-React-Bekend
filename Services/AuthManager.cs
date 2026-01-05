using System;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class AuthManager
    {
        private readonly UserStore _users;

        public AuthManager(UserStore users)
        {
            _users = users ?? throw new ArgumentNullException(nameof(users));
        }

        public async Task<UserDto> RegisterAsync(RegisterRequest registerUserDto)
        {
            if (await _users.UserExistsAsync(registerUserDto.Username, registerUserDto.Email))
            {
                throw new InvalidOperationException("Имя пользователя или email уже заняты");
            }

            var user = new User(
                registerUserDto.Username,
                registerUserDto.Email,
                PasswordHash.HashPassword(registerUserDto.Password)
            );

            var createdUser = await _users.AddAsync(user);

            return new UserDto
            {
                Id = createdUser.Id.ToString(),
                Username = createdUser.Username,
                Email = createdUser.Email
            };
        }

        public async Task<UserDto> LoginAsync(LoginRequest loginUserDto)
        {
            var user = await _users.GetByUsernameAsync(loginUserDto.Username);

            if (user == null || !PasswordHash.VerifyPassword(loginUserDto.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Неверное имя пользователя или пароль");
            }

            return new UserDto
            {
                Id = user.Id.ToString(),
                Username = user.Username,
                Email = user.Email
            };
        }
    }
}
