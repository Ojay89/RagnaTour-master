using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnaTour.Domain
{
    public class DisplayCatalog
    {
        private List<Display> _displays;
        private List<Tour> _tour1;
        private List<Tour> _tour2;
        private List<Tour> _tour3;
        private List<Tour> _tour4;

        public DisplayCatalog()
        {
            _displays = new List<Display>();
            _tour1 = new List<Tour>();
            _tour2 = new List<Tour>();
            _tour3 = new List<Tour>();
            _tour4 = new List<Tour>();
            _displays.Add(new Display(1,1,"navn","info"));
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
                        
                    }
                }
            }
        }
    }
}
