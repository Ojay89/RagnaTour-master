using RagnaTour.Persistency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnaTour.Domain
{
    public class DisplayCatalogSingleton
    {
        private List<Display> _displays;
        private PersistencyDisplay _fileSource;

        private DisplayCatalogSingleton()
        {
            _displays = new List<Display>();
           // _displays.Add(new Display(1, 1, "navn", "info"));
            _fileSource = new PersistencyDisplay();

        }

        private static DisplayCatalogSingleton _instance;

        public static DisplayCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DisplayCatalogSingleton();
                    return _instance;
                }
                else
                {
                    return _instance;
                }
            }
        }

        private int _count;

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        public List<Display> Displays
        {
            get { return _displays; }
            set { _displays = value; }
        }

        public void addDisplay(Display nd)
        {
            bool exist = false;
            if (_displays != null)
            {
                foreach (var d in _displays)
                {
                    if (d.ID == nd.ID) exist = true;
                }

                if (exist == false)
                    _displays.Add(nd);
            }
        }

        public void deleteDisplay(Display dd)
        {
            _displays.Remove(dd);
        }

        public void updateDisplay(Display ud)
        {
            if (_displays != null)
            {
                foreach (var d in _displays)
                {
                    if (d.ID == ud.ID)
                    {
                        d.Name = ud.Name;
                        d.Info = ud.Info;
                       
                    }
                }
            }
        }

        public async Task SaveAsync()
        {
            await _fileSource.SaveAsync(_displays);
        }

        public async Task<List<Display>> LoadAsync()
        {
            _displays = await _fileSource.LoadAsync();
            return _displays;
        }

    }


}



