using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnaTour.Domain
{
    public class UserCatalog
    {
        private List<User> _users;

        public UserCatalog()
        {
            _users = new List<User>();
            _users.Add(new User("Omar", "password", "Omar Jaber"));
            _users.Add(new User("Oliver", "password", "Oliver Eierstrand"));
            _users.Add(new User("Saad", "password", "Saad Hassan Kendt" ));
            _users.Add(new User("Chris", "password", "Chris seria"));
            _users.Add(new User("1", "1", "TEST"));
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
 


