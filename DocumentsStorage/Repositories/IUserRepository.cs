using DocumentsStorage.Models;

namespace DocumentsStorage.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);

        bool HasUser(User user);

        bool HasUser(string userName);
    }
}
