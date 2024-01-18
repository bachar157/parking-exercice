using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking_exercice
{
    internal class Dictionaries
    {
        Dictionary<int, string> CarPark = new Dictionary<int, string>();
        int CarParkavlable = 4;

        public Dictionary<int, string> readingTheInput()
        {
            for (int i = 1; i <= CarParkavlable; i++)
            {
                Console.WriteLine("enter your license number to resrve a park for your car:");
                string licenseNumber = Console.ReadLine();
                CarPark[i] = licenseNumber;
            }
            return CarPark;
        }
        public void validatThelicenseNumber() 
        { 
            if(readingTheInput() != null) { }

        }

    }
}
