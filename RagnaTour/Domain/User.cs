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
        private string _name;

        public User()
        {

        }

        public User(string username, string password, string name)
        {
            _username = username;
            _userPassword = password;
            _name = name;
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

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        
    }
}
