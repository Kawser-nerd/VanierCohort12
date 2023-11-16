using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCalculatorCohort12.Models
{
    public class Calculator
    {
        public double getAddition(double a, double b)
        {
            return a + b;
        }
        public double getSubstraction(double a, double b)
        {
            return a - b;
        }
        public double getMultiplication(double a, double b)
        {
            return a * b;
        }
        public double getDivision(double a, double b)
        {
            //return a % b; // accidentally put it
            return a / b;
        }
        public double getModulus(double a, double b)
        {
            //return a / b;
            return a % b;
        }
    }
}
