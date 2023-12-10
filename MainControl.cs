using System;
using System.IO;
using System.Collections.Generic;
using MapTemplate;
using ParkingPlaceNamespace;
using MapCreatorNamespace;

namespace MainControlNamespace
{
    public class MainControl
    {
        public void resOption(Map map, ParkingPlace[] parkingPlaces, string userInput)
        {
            try
            {   
                Console.Clear();
                map.displayMap();
                Console.Write("\nEnter slot number to reserve: ");
                userInput = Console.ReadLine();
                int slotNum = int.Parse(userInput);
                try
                {
                    parkingPlaces[slotNum-1].reserve(map);
                }
                catch (IndexOutOfRangeException)
                {
                    //Console.WriteLine(e.Message);
                    Console.WriteLine("Index parameter is out of range.\nPress any key to return");
                    userInput = Console.ReadLine();                            
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
        public void empOption(Map map, ParkingPlace[] parkingPlaces, string userInput)
        {
            try
            {   
                Console.Clear();
                map.displayMap();
                Console.Write("\nEnter slot number to release: ");
                userInput = Console.ReadLine();
                int slotNum = int.Parse(userInput);
                try
                {
                    parkingPlaces[slotNum-1].release(map);
                }
                catch (IndexOutOfRangeException)
                {
                    //Console.WriteLine(e.Message);
                    Console.WriteLine("Index parameter is out of range.\nPress any key to return");
                    userInput = Console.ReadLine();                            
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }            
        }
        public void toutOption(Map map, ParkingPlace[] parkingPlaces, string userInput)
        {
            try
            {   
                Console.Clear();
                map.displayMap();
                Console.Write("\nEnter slot number: ");
                userInput = Console.ReadLine();
                int slotNum = int.Parse(userInput);
                try
                {
                    Console.WriteLine("This spot has been last released at: " + parkingPlaces[slotNum-1].getTimeReleased());
                    Console.WriteLine("Pres any key to return.");
                    userInput = Console.ReadLine();                            
                }
                catch (IndexOutOfRangeException)
                {
                    //Console.WriteLine(e.Message);
                    Console.WriteLine("Index parameter is out of range.\nPress any key to return");
                    userInput = Console.ReadLine();                            
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
        public void tinOption(Map map, ParkingPlace[] parkingPlaces, string userInput)
        {
            try
            {   
                Console.Clear();
                map.displayMap();
                Console.Write("\nEnter slot number: ");
                userInput = Console.ReadLine();
                int slotNum = int.Parse(userInput);
                try
                {
                Console.WriteLine("This spot has been last reserved at: " + parkingPlaces[slotNum-1].getTimeReserved());
                Console.WriteLine("Pres any key to return.");
                userInput = Console.ReadLine();
                }
                catch (IndexOutOfRangeException)
                {
                    //Console.WriteLine(e.Message);
                    Console.WriteLine("Index parameter is out of range.\nPress any key to return");
                    userInput = Console.ReadLine();                            
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }
}