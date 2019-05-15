using System;
using RagnaTour.Domain;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;
//using RagnaTour.ViewModel;


namespace RagnaTour.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private UserCatalogSingleton singleton;
        private ObservableCollection<User> _users;
        private User _selectedUser;
        //private UserCatalog userCatalog;
        


        public UserViewModel()
        {
            singleton = UserCatalogSingleton.Instance;
            AddCommand = new RelayCommand(toAddNewUser);
            DeleteCommand = new RelayCommand(toDeleteUser);
            _users = new ObservableCollection<User>();
            _selectedUser = new User();
            //userCatalog = new UserCatalog();

        }

        public ObservableCollection<User> all_Users
        {
            get
            {
                _users = new ObservableCollection<User>(singleton.Users);
                return _users;
            }
        }
 
        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }

        public bool DoesUserExist(string username, string password)
        {
            User myuser = new User(username, password);
            //bool check = userCatalog.CheckLogin(myuser);
            bool check = singleton.CheckLogin(myuser);

            return check;

        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public int UserCount
        {
            get { return singleton.Users.Count; }
        }



        public void toAddNewUser()
        {
            User NewUser = new User(_username, _password);

            singleton.addUser(NewUser);
            OnPropertyChanged(nameof(all_Users));
            OnPropertyChanged(nameof(UserCount));
        }


        public User SelectedUser
        {
            get { return _selectedUser; }
            set { _selectedUser= value; OnPropertyChanged(); }
        }


        public void toDeleteUser()
        {
            singleton.deleteUser(SelectedUser);
            OnPropertyChanged(nameof(all_Users));
            OnPropertyChanged(nameof(UserCount));
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged
            ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new
                PropertyChangedEventArgs(propertyName));
        }
    }
}

