using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.AllJoyn;
using Windows.Devices.Input;
using RagnaTour.Domain;
using RagnaTour.ViewModel;

namespace RagnaTour.ViewModel
{
    public class DisplayViewModel : INotifyPropertyChanged
    {

        

        //private DisplayCatalog catalog;
        private DisplayCatalogSingleton singleton;
        private ObservableCollection<Display> _displays;
        private Display _selectedDisplay;
        //private DisplayCatalog catalog;

        public DisplayViewModel()
        {
            singleton = DisplayCatalogSingleton.Instance;
            AddCommand = new RelayCommand(toAddNewDisplay);
            DeleteCommand = new RelayCommand(toDeleteDisplay);
            UpdateCommand = new RelayCommand(toUpdateDisplay);
            SaveCommand = new RelayCommand(SaveToFile);
            Load();
            _displays = new ObservableCollection<Display>();
            _selectedDisplay = new Display();
            //catalog = new DisplayCatalog();
        }

        public ObservableCollection<Display> all_Displays
        {
            get
            {
                _displays = new ObservableCollection<Display>(singleton.Displays);
                return _displays;
            }
        }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _info;
        public string Info
        {
            get { return _info; }
            set { _info = value; }
        }

        private int _location;
        public int Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public int DisplayCount
        {
            get { return singleton.Displays.Count; }
        }


        public void toAddNewDisplay()
        {
            Display NewDisplay = new Display(_id, _location, _name, _info);

            singleton.addDisplay(NewDisplay);
            SaveToFile();
            OnPropertyChanged(nameof(all_Displays));
            OnPropertyChanged(nameof(DisplayCount));
        }

        public void toDeleteDisplay()
        {
            singleton.deleteDisplay(SelectedDisplay);
            OnPropertyChanged(nameof(all_Displays));
            OnPropertyChanged(nameof(DisplayCount));
        }

        public void toUpdateDisplay()
        {
            singleton.updateDisplay(SelectedDisplay);
            OnPropertyChanged(nameof(all_Displays));
            
        }

        public Display SelectedDisplay
        {
            get { return _selectedDisplay; }
            set { _selectedDisplay = value; OnPropertyChanged(); }
        }

        public void SaveToFile()
        {

            singleton.SaveAsync();
        }

        private void Load()
        {

            singleton.LoadAsync();
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



