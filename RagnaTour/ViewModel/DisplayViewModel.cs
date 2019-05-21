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

        
        private DisplayCatalogSingleton singleton;
        private ObservableCollection<Display> _displays;
        private ObservableCollection<Display> _tour1;
        private ObservableCollection<Display> _tour2;
        private Display _selectedDisplay;
        private TourCatalog _tourCatalog;

        public DisplayViewModel()
        {
            singleton = DisplayCatalogSingleton.Instance;
            AddCommand = new RelayCommand(toAddNewDisplay);
            DeleteCommand = new RelayCommand(toDeleteDisplay);
            UpdateCommand = new RelayCommand(toUpdateDisplay);
            SaveCommand = new RelayCommand(SaveToFile);
            SaveCommandTour = new RelayCommand(SaveToFileTour);
            Load();
            AddR1 = new RelayCommand(toAddR1);
            AddR2 = new RelayCommand(toAddR2);
            AddR3 = new RelayCommand(toAddR3);
            AddR4 = new RelayCommand(toAddR4);
            _displays = new ObservableCollection<Display>();
            _tour1 = new ObservableCollection<Display>();
            _selectedDisplay = new Display();
            _tourCatalog = new TourCatalog();
            LoadTour();

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

        public ObservableCollection<Display> tour1
        {
            get
            {
                _tour1 = new ObservableCollection<Display>(_tourCatalog.Tour1);
                //_tour1.Add(new Display(1, 1, "MJ", "jfwjfe"));
                return _tour1;
            }
            set
            {
                _tour1 = value;
                OnPropertyChanged(nameof(_tour1));
            }
        }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand SaveCommandTour { get; set; }
        public RelayCommand AddR1 { get; set; }
        public RelayCommand AddR2 { get; set; }
        public RelayCommand AddR3 { get; set; }
        public RelayCommand AddR4 { get; set; }

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

        public async void SaveToFile()
        {

            await singleton.SaveAsync();
        }

        private async void Load()
        {

           await singleton.LoadAsync();
        }

        public async void SaveToFileTour()
        {

           await _tourCatalog.SaveAsync();
        }

        private  void LoadTour()
        {

            //await _tourCatalog.LoadAsync();
            _tour1 = new ObservableCollection<Display>(_tourCatalog.Tour1);
            //OnPropertyChanged(nameof(tour1));;
        }

        public void toAddR1()
        {
            _tourCatalog.addTour1(SelectedDisplay);
            
        }

        public void toAddR2()
        {
            _tourCatalog.addTour2(SelectedDisplay);
        }

        public  void toAddR3()
        {
           _tourCatalog.addTour3(SelectedDisplay);
        }

        public void toAddR4()
        {
            _tourCatalog.addTour4(SelectedDisplay);
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



