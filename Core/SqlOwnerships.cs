using Microsoft.EntityFrameworkCore;
using System.Net;
using TestTask.Interfaces;
using TestTask.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestTask.Core
{
    public class SqlOwnerships : IAllOwnerships
    {
        private readonly ApplicationDbContext _db;
        public SqlOwnerships(ApplicationDbContext db)
        {
            _db = db;
        }

        public Ownership CreateNewOwnership(Ownership newOwn)
        { 
            _db.Add(newOwn);
            _db.SaveChanges();
            return newOwn;
        }

        public void DeleteOwnership(int id)
        {
            _db.Ownerships.Remove(_db.Ownerships.SingleOrDefault(u => u.Id == id));
            _db.SaveChanges();
        }

        public void EditOwnership(Ownership EditedOwnership)
        {
            _db.Ownerships.Update(EditedOwnership);
            _db.SaveChanges();
        }

        public Ownership GetObjectOwnership(int Id)
        {
            return _db.Ownerships.Where(o => o.Id == Id).FirstOrDefault();
        }

        public List<Ownership> GetAllOwnerships() => _db.Ownerships.ToList();
    }
}
