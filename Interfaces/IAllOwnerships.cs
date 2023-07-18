using TestTask.Models;

namespace TestTask.Interfaces
{
    public interface IAllOwnerships
    {
        Ownership GetObjectOwnership(int Id);

        Ownership CreateNewOwnership(Ownership newOwn);

        void EditOwnership(Ownership editedOwn);

        List<Ownership> GetAllOwnerships();

        void DeleteOwnership(int id);
    }
}
