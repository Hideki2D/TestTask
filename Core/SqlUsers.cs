using TestTask.Interfaces;
using TestTask.Models;

namespace TestTask.Core
{
    public class SqlUsers : IAllUsers
    {
        private readonly ApplicationDbContext _db;

        public SqlUsers(ApplicationDbContext db) 
        {
            _db = db;
        }

        public User CreateNewUser(User newUser)
        {
            _db.Add(newUser);
            _db.SaveChanges();
            return newUser;
        }

        public void DeleteUser(int id)
        {
            _db.Users.Remove(_db.Users.SingleOrDefault(u=>u.Id == id));
            _db.SaveChanges();
        }

        public void EditUser(User editedUser)
        {
            _db.Users.Update(editedUser);
            _db.SaveChanges();
        }

        public List<User> GetAllUsers() => _db.Users.ToList();


        public User GetObjectUser(int id)
        {
            return _db.Users.SingleOrDefault(u => u.Id == id);
        }

        public bool isUserExist(int id)
        {
          return _db.Users.Find(id) != null;
        }
    }
}
