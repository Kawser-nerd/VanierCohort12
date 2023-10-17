using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cohort_12_week1cls2
{
    internal class CruiseShip : Ship
    {
        private int _maxPassengers;
        public CruiseShip(string shipName, int builtYear, int maxPassengers) : 
            base(shipName, builtYear)
        {
            _maxPassengers = maxPassengers;
        }

        public int getMaxPassengers()
        {
            return _maxPassengers;
        }

        public override string ToString()
        {
            return ("The name of the ship is " + getShipName() +
                "\n" + "The maximum number of passengers is "+ this._maxPassengers);
        }
    }
}
