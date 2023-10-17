using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cohort_12_week1cls2
{
    internal class Ship
    {
        private string _shipName;
        private int _builtYear;

        //public int _buildYear { get; set; }

        public Ship(string shipName, int builtYear ) { // constructor
            this._shipName = shipName;
            this._builtYear = builtYear;
        }

        public string getShipName()
        {
            return this._shipName;
        }
        public int getBuiltYear()
        {
            return this._builtYear; 
        }

        public override string ToString()
        {
            return ("The ship name is " + this._shipName + "\n"
                + " & the ship was built on " + this._builtYear);
        }

    }
}
