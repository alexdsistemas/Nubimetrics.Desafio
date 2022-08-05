
using Entities;

namespace UseCases.Usuarios.Services
{
    public interface IUserRepository
    {
        User CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        Task<bool> UserExists(int id);
        Task<User?> GetUserById(int id);
        Task<List<User>> GetAllUsers();
    }
}
