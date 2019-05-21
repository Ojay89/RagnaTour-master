using RagnaTour.Persistency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnaTour.Domain
{
    public class TourCatalog
    {
        private List<Display> _tour1;
        private List<Display> _tour2;
        private List<Display> _tour3;
        private List<Display> _tour4;
        private PersistencyTour _fileSource;

        public TourCatalog()
        {
            _tour1 = new List<Display>();
            _tour2 = new List<Display>();
            _tour3 = new List<Display>();
            _tour4 = new List<Display>();
            _tour1.Add(new Display(1, 1, "navn", "info"));
            _fileSource = new PersistencyTour();
        }


        public List<Display> Tour1
        {
            get { return _tour1; }
            set { _tour1 = value; }
        }

        public List<Display> Tour2
        {
            get { return _tour2; }
            set { _tour2 = value; }
        }

        public List<Display> Tour3
        {
            get { return _tour3; }
            set { _tour3 = value; }
        }

        public List<Display> Tour4
        {
            get { return _tour4; }
            set { _tour4 = value; }
        }

        public void addTour1(Display nt)
        {
            bool exist = false;
            if (_tour1 != null)
            {
                foreach (var d in _tour1)
                {
                    if (d.ID == nt.ID) exist = true;
                }

                if (exist == false)
                    _tour1.Add(nt);
            }
        }

        public void deleteTour(Display dt)
        {
            _tour1.Remove(dt);
        }


        public void addTour2(Display nt)
        {
            bool exist = false;
            if (_tour2 != null)
            {
                foreach (var d in _tour2)
                {
                    if (d.ID == nt.ID) exist = true;
                }

                if (exist == false)
                    _tour2.Add(nt);
            }
        }

        public void deleteTour2(Display dt)
        {
            _tour2.Remove(dt);
        }


        public void addTour3(Display nt)
        {
            bool exist = false;
            if (_tour3 != null)
            {
                foreach (var d in _tour3)
                {
                    if (d.ID == nt.ID) exist = true;
                }

                if (exist == false)
                    _tour3.Add(nt);
            }
        }

        public void deleteTour3(Display dt)
        {
            _tour3.Remove(dt);
        }


        public void addTour4(Display nt)
        {
            bool exist = false;
            if (_tour4 != null)
            {
                foreach (var d in _tour4)
                {
                    if (d.ID == nt.ID) exist = true;
                }

                if (exist == false)
                    _tour4.Add(nt);
            }
        }

        public void deleteTour4(Display dt)
        {
            _tour4.Remove(dt);
        }

        public async Task SaveAsync()
        {
            await _fileSource.SaveAsync(_tour1);
        }

        public async Task<List<Display>> LoadAsync()
        {
            _tour1 = await _fileSource.LoadAsync();
            return _tour1;
        }


    }
}
