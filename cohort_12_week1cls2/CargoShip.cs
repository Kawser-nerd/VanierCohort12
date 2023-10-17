using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cohort_12_week1cls2
{
    internal class CargoShip : Ship
    {
        private double _capacity;
        public CargoShip(string shipName, int builtYear, double capacity) : 
            base(shipName, builtYear)
        {
            this._capacity = capacity;
        }

        public double getMaxCapacity()
        {
            return this._capacity;
        }

        public override string ToString()
        {
            return ("The name of the ship is " + getShipName() + "\n" 
                + " & The maximum capacity is " + this._capacity);
        }
    }
}
