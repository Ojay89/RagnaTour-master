using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnaTour.Domain
{
    public class UserCatalogSingleton
    {
        private List<User> _users;

        private UserCatalogSingleton()
        {
            _users = new List<User>();
            _users.Add(new User("Omar", "1234"));
            _users.Add(new User("Oliver", "password"));
            _users.Add(new User("Saad", "password"));
            _users.Add(new User("Chris", "password"));
            _users.Add(new User("1", "1"));
        }

        private static UserCatalogSingleton _instance;

        public static UserCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserCatalogSingleton();
                    return _instance;
                }
                else
                {
                    return _instance;
                }
            }
        }

        public bool CheckLogin(User user)
        {
            bool exist = false;

            if (_users != null)
            {
                foreach (var u in _users)
                {
                    if (u.UserName == user.UserName && u.UserPassword == user.UserPassword)
                        exist = true;
                }
                return exist;
            }

            return exist;
        }

        private int _countUsers;
        public int CountUsers
        {
            get { return _countUsers; }
            set { _countUsers = value; }
        }

        public List<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }

        public void addUser(User nu)
        {
            bool exist = false;
            if (_users != null)
            {
                foreach (var u in _users)
                {
                    if (u.UserName == nu.UserName) exist = true;
                }

                if (exist == false)
                    _users.Add(nu);
            }
        }

        public void deleteUser(User du)
        {
            _users.Remove(du);
        }

    }
}
 

