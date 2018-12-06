using System.Collections.Generic;
using Wonder.Core.Models;

namespace Wonder.Core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Resultado<User> RegisterUser(User user);
        Resultado<User> EditUser(User user);
        Resultado<User> DeleteUser(int user);
        Resultado<List<User>> GetAllUser();
        Resultado<User> GetUser(int id);

        Resultado<List<User>> FullSearch(string query);
    }
}
