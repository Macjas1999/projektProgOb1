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
        protected Map map;
        protected ParkingPlace[] parkingPlaces;
        public string userInput;

        public MainControl(Map map, ParkingPlace[] parkingPlaces)
        {
            this.map = map;
            this.parkingPlaces = parkingPlaces;
        }
        public void resOption()
        {
            try
            {   
                Console.Clear();
                this.map.displayMap();
                Console.Write("\nEnter slot number to reserve: ");
                this.userInput = Console.ReadLine();
                int slotNum = int.Parse(this.userInput);
                try
                {
                    this.parkingPlaces[slotNum-1].reserve(this.map);
                }
                catch (IndexOutOfRangeException)
                {
                    //Console.WriteLine(e.Message);
                    Console.WriteLine("Index parameter is out of range.\nPress any key to return");
                    this.userInput = Console.ReadLine();                            
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
        public void empOption()
        {
            try
            {   
                Console.Clear();
                this.map.displayMap();
                Console.Write("\nEnter slot number to release: ");
                userInput = Console.ReadLine();
                int slotNum = int.Parse(userInput);
                try
                {
                    parkingPlaces[slotNum-1].release(this.map);
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
        public void toutOption()
        {
            try
            {   
                Console.Clear();
                this.map.displayMap();
                Console.Write("\nEnter slot number: ");
                this.userInput = Console.ReadLine();
                int slotNum = int.Parse(this.userInput);
                try
                {
                    Console.WriteLine("This spot has been last released at: " + this.parkingPlaces[slotNum-1].getTimeReleased());
                    Console.WriteLine("Pres any key to return.");
                    this.userInput = Console.ReadLine();                            
                }
                catch (IndexOutOfRangeException)
                {
                    //Console.WriteLine(e.Message);
                    Console.WriteLine("Index parameter is out of range.\nPress any key to return");
                    this.userInput = Console.ReadLine();                            
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
        public void tinOption()
        {
            try
            {   
                Console.Clear();
                this.map.displayMap();
                Console.Write("\nEnter slot number: ");
                this.userInput = Console.ReadLine();
                int slotNum = int.Parse(this.userInput);
                try
                {
                Console.WriteLine("This spot has been last reserved at: " + this.parkingPlaces[slotNum-1].getTimeReserved());
                Console.WriteLine("Pres any key to return.");
                this.userInput = Console.ReadLine();
                }
                catch (IndexOutOfRangeException)
                {
                    //Console.WriteLine(e.Message);
                    Console.WriteLine("Index parameter is out of range.\nPress any key to return");
                    this.userInput = Console.ReadLine();                            
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }
}