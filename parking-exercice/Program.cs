using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking_for_cars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionaries dictionaries = new Dictionaries();
            dictionaries.createparking();
            Dictionaries dictionaries1 = new Dictionaries();
           // dictionaries1.bookingTheParking();
            Console.ReadLine();
        }
    }
}
