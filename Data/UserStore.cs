using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class UserStore
    {
        private readonly AppDbContext _db;

        public UserStore(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public Task<User?> GetByUsernameAsync(string username)
        {
            return _db.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            return _db.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public Task<User?> GetByIdAsync(string id)
        {
            return _db.Users.FirstOrDefaultAsync(u => u.Id.ToString().ToLower() == id.ToLower());
        }

        public async Task<User> AddAsync(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public Task<bool> UserExistsAsync(string username, string email)
        {
            return _db.Users.AnyAsync(u =>
                u.Username.ToLower() == username.ToLower() ||
                u.Email.ToLower() == email.ToLower());
        }
    }
}
