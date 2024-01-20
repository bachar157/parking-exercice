using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace parking_for_cars
{
    internal class Dictionaries
    {
        Dictionary<int, string> InitializeCarPark = new Dictionary<int, string>();
        Dictionary<int, string> TheEmptyParking;
        int maxParks = 7;
        string licenseNumber;
        string parkinNumberBeforCheck;
        /// <summary>
        /// this function has been here to create the empty parking  
        /// </summary>
        public void createparking()
        {
            for (int i = 1; i <= maxParks; i++)
            {
                string licenseNumber = null;
                InitializeCarPark[i] = licenseNumber;
            }

            setTheCarInParking(InitializeCarPark);


        }
        /// <summary>
        /// this is the main  function which is i called all of the others fdunction here  
        /// </summary>
        /// <param name="TheEmptyParking"></param>
        public void setTheCarInParking(Dictionary<int, string> TheEmptyParking)

        {
            try
            {
                Console.WriteLine(" _________________________________  ");

                Console.WriteLine($" \n  enter : 8  to remove any car  && enter : 9  to display the parking stutes \n  ");

                Console.WriteLine($" \n take your parking right a way with BACHAR Company");
                Console.WriteLine(" enter the parking number that you want (1 to 7): ");

                parkinNumberBeforCheck = Console.ReadLine();  // the pure value from the user 
                int parkinNumberafterCheck = unvalidParkingNumber(parkinNumberBeforCheck); // check the input and make sure it is (1-9) and intger
                removeTheCars(TheEmptyParking, parkinNumberafterCheck);// call the fumction to remove any car 
                dispalyTheAvailableParking(TheEmptyParking, parkinNumberafterCheck); // function to dispaly the parking stuats 
                Console.WriteLine($"write the license Number of your car to park it here  witrh correct formating :");
                licenseNumber = Console.ReadLine();
                try
                {
                    if (TheEmptyParking[parkinNumberafterCheck] == null && PreventDuplicate(TheEmptyParking)) // making sure the is no Duplicate license Number and it spot is empty to park 
                    {
                        TheEmptyParking[parkinNumberafterCheck] = licenseNumber;
                        bookingTheParking(TheEmptyParking, parkinNumberafterCheck);// here to confiem the booking 
                    }

                    else if (TheEmptyParking[parkinNumberafterCheck] != null)
                    {
                        Console.WriteLine($" sorry the parking Number {parkinNumberafterCheck} is  busy now try later or try with anther parking   thnks :)");
                        setTheCarInParking(TheEmptyParking); // recall the program in case this parking is busy 

                    }
                    else if (!PreventDuplicate(TheEmptyParking))
                    {
                        setTheCarInParking(TheEmptyParking);// recall the program in case this  license Number is  Duplicate
                    }
                }
                catch
                {
                    throw;
                }

            }
            catch (Exception e)
            {
                throw e;
            }        




        }
        public void bookingTheParking(Dictionary<int, string> InitialInput, int parkinNumberafterCheck)
        {
            try  
        
            {
                if (licenseNumberValidat(InitialInput[parkinNumberafterCheck])) // valdiat the license Number and making sure it is (xxx-xxx)
                {


                    Console.WriteLine($" You have booked parking {parkinNumberafterCheck} for your car license plate:{InitialInput[parkinNumberafterCheck]}");


                }
                else
                {


                    Console.WriteLine(" your car license plate should be like (XXX-XXX)- try again:");
                    InitialInput.Remove(parkinNumberafterCheck); // to make sure the wrong license Number will not be saved in the parking  
                }
              
                setTheCarInParking(InitialInput);
            }catch (Exception e) { throw e; }
        }

        /// <summary>
        /// this bool  function to valiat the licese number 
        /// </summary>
        /// <param name="licenseNumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool licenseNumberValidat(string licenseNumber)
        {
            try
            {  // Check if the length is exactly 7 characters (including hyphen)
                if (licenseNumber.Length != 7)
                {
                    return false;
                }

                // Check if the fourth character is a hyphen
                if (licenseNumber[3] != '-')
                {
                    return false;
                }

                // Check if all other characters are alphanumeric
                for (int i = 0; i < licenseNumber.Length; i++)
                {
                    if (i == 3) continue; // Skip the hyphen

                    if (!char.IsLetterOrDigit(licenseNumber[i]))
                    {
                        return false;
                    }
                }

                return true;
            }
            catch
            {
                throw new Exception();
            };
        }
        /// <summary>
        /// this function has beet created to check if the parking number that the user added is intger
        /// </summary>
        /// <param name="parkinNumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int checkTheParkingNumber(string parkinNumber)
        {
            try
            {
                int number;

                bool result = int.TryParse(parkinNumber, out number);

                if (result)
                {
                    return number;
                }
                return -1;

            }
            catch
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// this function has beet created to check if the parking number that the user added is intger and between 1-9
        /// </summary>
        /// <param name="parkinNumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int unvalidParkingNumber(string parkinNumber)
        {
            try
            {
                int number = checkTheParkingNumber(parkinNumber);
                if (number > 9 || number < 1)
                {
                    Console.WriteLine("plz enter a valid number betwwen 1 to 6 ");
                    setTheCarInParking(TheEmptyParking);
                }
                return number;

            }
            catch
            {
                throw new Exception();

            }
        }
        /// <summary>
        /// in this function i want to make sure there are no Duplicate for the new license Number and with the license Number already there 
        /// </summary>
        /// <param name="TheEmptyParking"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool PreventDuplicate(Dictionary<int, string> TheEmptyParking)
        {
            try
            {

                foreach (var entry in TheEmptyParking)
                {
                    if (entry.Value == licenseNumber)
                    {
                        Console.WriteLine($"Your car that has the following plate number {licenseNumber} already exists");
                        return false;
                    }


                }
                return true;
            }
            catch { throw new Exception(); }

        }
        /// <summary>
        /// when user wrtie 8 it will give him chance to remove any car by this function
        /// </summary>
        /// <param name="TheEmptyParking"></param>
        /// <param name="parkinNumberafterCheck"></param>
        public void removeTheCars(Dictionary<int, string> TheEmptyParking, int parkinNumberafterCheck)
        {
            try
            {
                if (parkinNumberafterCheck == 8)
                {
                    Console.WriteLine("Enter the plate number of the car that you want to remove: ");
                    string removalCar = Console.ReadLine();

                    List<int> keysToRemove = new List<int>();

                    foreach (var kvp in TheEmptyParking)
                    {
                        if (removalCar == kvp.Value && licenseNumberValidat(removalCar))
                        {
                            keysToRemove.Add(kvp.Key);
                            Console.WriteLine($"The car with the plate number {removalCar} has been marked for removal.");
                        }
                    }

                    foreach (var key in keysToRemove)
                    {
                        TheEmptyParking[key] = null;
                    }

                    if (keysToRemove.Count > 0)
                    {
                        Console.WriteLine("The marked cars have been removed and their places are free now.");
                    }
                    else
                    {
                        Console.WriteLine("No car with the specified plate number was found.");
                    }
                    setTheCarInParking(TheEmptyParking);

                }
            }
            catch (Exception e)
            { throw e; }

        }
        /// <summary>
        /// this function give user chance to dispaly all of the parking spots  the Available and  the occupied 
        /// </summary>
        /// <param name="TheEmptyParking"></param>
        /// <param name="parkinNumberafterCheck"></param>
        public void dispalyTheAvailableParking(Dictionary<int, string> TheEmptyParking, int parkinNumberafterCheck)
        {
            try
            {
                if (parkinNumberafterCheck == 9)
                {
                    Console.WriteLine("Available parking:");

                    foreach (KeyValuePair<int, string> kvp in TheEmptyParking)
                    {
                        if (TheEmptyParking.TryGetValue(kvp.Key, out string parkedCar) && !string.IsNullOrEmpty(parkedCar))
                        {
                            Console.WriteLine($"The parking number: {kvp.Key} is occupied by car that has the following plate number: {parkedCar}");
                        }
                        else
                        {
                            Console.WriteLine($"The parking number: {kvp.Key} is available");
                        }
                    }
                    setTheCarInParking(TheEmptyParking);
                }
            }catch (Exception e) { throw e; }
        }
    }

}
