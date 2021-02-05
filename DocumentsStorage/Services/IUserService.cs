using DocumentsStorage.Models;

namespace DocumentsStorage.Services
{
    public interface IUserService
    {
        void Add(User user);

        bool HasUser(User user);

        bool HasUser(string userName);
    }
}
