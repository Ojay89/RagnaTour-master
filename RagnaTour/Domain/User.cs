using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnaTour.Domain
{
    public class User
    {
        private string _username;
        private string _userPassword;

        public User()
        {

        }

        public User(string username, string password)
        {
            _username = username;
            _userPassword = password;
        }
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        public string UserPassword
        {
            get { return _userPassword; }
            set { _userPassword = value; }
        }

    }
}
