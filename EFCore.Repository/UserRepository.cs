using Entities;
using ExceptionHandler;
using Microsoft.EntityFrameworkCore;
using UseCases.Usuarios.Services;

namespace EFCore.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly ChallengeDataContext context;

        public UserRepository(ChallengeDataContext context)
        {
            this.context = context;
        }

        public User CreateUser(User user)
        {

            context.Add(user);

            return user;

        }

        public void DeleteUser(User user)
        {
            context.Remove(user);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await context.Users.ToListAsync();

        }

        public async Task<User?> GetUserById(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public void UpdateUser(User user)
        {
            context.Update(user);
        }

        public Task<bool> UserExists(int id)
        {
            return context.Users.AnyAsync(x => x.Id == id);
        }
    }
}
