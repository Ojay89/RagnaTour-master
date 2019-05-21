using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnaTour.Domain
{
    public class Tour
    {
        private int _id;
        private string _name;
        private int _location;
        private string _info;

        public Tour()
        {

        }

        public Tour(int id, int location, string name, string info)
        {
            _id = id;
            _name = name;
            _location = location;
            _info = info;
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Info
        {
            get { return _info; }
            set { _info = value; }
        }

    }
}
