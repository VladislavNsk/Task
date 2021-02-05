using System.Linq;

using DocumentsStorage.Models;

namespace DocumentsStorage.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void Add(User user)
        {
            using (var context = new UserContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public bool HasUser(User user)
        {
            var hasUser = false;

            using (var context = new UserContext())
            {
                var searchedUser = context.Users.FirstOrDefault(u => u.Login == user.Login && u.Pass == user.Pass);

                if (searchedUser != null)
                {
                    hasUser = true;
                }
            }

            return hasUser;
        }

        public bool HasUser(string userName)
        {
            var hasUser = false;

            using (var context = new UserContext())
            {
                var searchedUser = context.Users.FirstOrDefault(u => u.Login == userName);

                if (searchedUser != null)
                {
                    hasUser = true;
                }
            }

            return hasUser;
        }
    }
}