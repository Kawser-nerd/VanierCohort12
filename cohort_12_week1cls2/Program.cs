namespace cohort_12_week1cls2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
             * Going to ask the user to insert two values and add them together
             *

            //Console.WriteLine("Hello, World!");

            double var1, var2, result;

            Console.WriteLine("Enter the first value");
            var1 = double.Parse( Console.ReadLine());
            /*
             * Console.ReadLine() always read everything in String format from user
             * So, we need to covert the value to the destination Datatype
             * 
             * To do that, we need to use the destination datatype with the parse() method
             *
            Console.WriteLine("Enter the second value");
            var2 = double.Parse( Console.ReadLine());

            result = var1 + var2;
            Console.WriteLine("The result of the addition is " + result);
            */

            /* One way to comment
             */

            // Single line comment

            Ship[] _ships = new Ship[3]; // array of objects  

            // First Instance for Ship class
            _ships[0] = new Ship("Casablanca", 1934);

            // Second Instance for CruiseShip class
            _ships[1] = new CruiseShip("MontCruise", 2001, 320);

            // THird Instance for CargoShip class
            _ships[2] = new CargoShip("MontCargo", 1984, 150.34);

            Console.WriteLine(_ships[0].ToString());
            Console.WriteLine(_ships[1].ToString());
            Console.WriteLine(_ships[2].ToString());


        }
    }
}