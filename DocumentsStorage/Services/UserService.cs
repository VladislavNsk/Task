using DocumentsStorage.Models;
using DocumentsStorage.Repositories;

namespace DocumentsStorage.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public bool HasUser(User user)
        {
            return _userRepository.HasUser(user);
        }

        public bool HasUser(string userName)
        {
            return _userRepository.HasUser(userName);
        }
    }
}