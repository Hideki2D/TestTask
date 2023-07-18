using System.Net;
using TestTask.Models;

namespace TestTask.Interfaces
{
    public interface IAllUsers
    {
        User GetObjectUser(int id);

        User CreateNewUser(User newUser);
        
        void EditUser(User editedUser);

        void DeleteUser(int id);

        bool isUserExist(int id);

        List<User> GetAllUsers();
    }
}
