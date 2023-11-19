using System;
using System.Collections.Generic;

namespace MainContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();
            ParkingPlace[] parkingPlaces = new ParkingPlace[42];
            for (int i = 0; i < parkingPlaces.Length; i++)
            {
                parkingPlaces[i] = new ParkingPlace(i+1);
            }

            //Console.WriteLine(map.placeLocationOnMap[1][0]);
            //Console.WriteLine(map.mapImg[map.locOnMap[1][0],map.locOnMap[1][1]]);

            // program.displayMain();
            // parkingPlaces[1].reserve(map);
            // parkingPlaces[2].reserve(map);
            // parkingPlaces[12].reserve(map);
            // parkingPlaces[13].reserve(map);
            // Console.Clear();
            // program.displayMain();
            Console.Clear();
            bool run = true;
            while (run)
            {
                Console.Clear();
                map.displayMap();
                Console.WriteLine("To reserve slot type \"res\"");
                Console.WriteLine("To release slot type \"emp\"");
                Console.WriteLine("To check release time type \"tout\"");
                Console.WriteLine("To chek reserve time type \"tin\"");
                Console.WriteLine("To exit type \"exit\"");


                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "res":
                        try
                        {   
                            Console.Clear();
                            map.displayMap();
                            Console.Write("\nEnter slot number to reserve: ");
                            userInput = Console.ReadLine();
                            int slotNum = int.Parse(userInput);
                            parkingPlaces[slotNum-1].reserve(map);
                            break;

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                            break;
                        }
                    case "emp":
                        try
                        {   
                            Console.Clear();
                            map.displayMap();
                            Console.Write("\nEnter slot number to release: ");
                            userInput = Console.ReadLine();
                            int slotNum = int.Parse(userInput);
                            parkingPlaces[slotNum-1].release(map);
                            break;

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                            break;
                        }

                    case "tout":
                        try
                        {   
                            Console.Clear();
                            map.displayMap();
                            Console.Write("\nEnter slot number: ");
                            userInput = Console.ReadLine();
                            int slotNum = int.Parse(userInput);
                            Console.WriteLine("This spot has been last released at: " + parkingPlaces[slotNum-1].getTimeReleased());
                            Console.WriteLine("Pres any key to return.");
                            userInput = Console.ReadLine();                            
                            break;

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                            break;
                        }
                    case "tin":
                        try
                        {   
                            Console.Clear();
                            map.displayMap();
                            Console.Write("\nEnter slot number: ");
                            userInput = Console.ReadLine();
                            int slotNum = int.Parse(userInput);
                            Console.WriteLine("This spot has been last reserved at: " + parkingPlaces[slotNum-1].getTimeReserved());
                            Console.WriteLine("Pres any key to return.");
                            userInput = Console.ReadLine();
                            break;

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                            break;
                        }
                    case "exit":
                        run = false;
                        break;
                    
                    default:
                        Console.WriteLine("Wrong input, pres any key to return.");
                        userInput = Console.ReadLine();
                        Console.Clear();
                        continue;
                }
            }
        }
    }
    class Map
    {
        private string[,] mapImg =  {{"##","###","###","###","###","###","###","###","###","###","###","###","###","#\n"},
                                    {"#|"," 1|"," 2|"," 3|"," 4|"," 5|"," 6|"," 7|"," 8|"," 9|","10|","11|","12|","#\n"},
                                    {"#|","  |","  |","  |","  |","  |","  |","  |","  |","  |","  |","  |","  |","#\n"},
                                    {"# ","   ","   ","   ","   ","   ","   ","   ","   ","   ","   ","   ","   ","#\n"},
                                    {"# ","  |","  |","  |","  |","  |","  |","  |","  |","  |","  |","   ","   ","#\n"},
                                    {"#|","13|","14|","15|","16|","17|","18|","19|","20|","21|","22|","   ","   ","#\n"},
                                    {"##","###","###","###","###","###","###","###","###","###","###","   ","   ","#\n"},
                                    {"#|","23|","24|","25|","26|","27|","28|","29|","30|","31|","32|","   ","   ","#\n"},
                                    {"# ","  |","  |","  |","  |","  |","  |","  |","  |","  |","  |","   ","   ","#\n"},
                                    {"# ","   ","   ","   ","   ","   ","   ","   ","   ","   ","   ","   ","   ","#\n"},
                                    {"#|","  |","  |","  |","  |","  |","  |","  |","  |","  |","  |","   ","   ","#\n"},
                                    {"#|","33|","34|","35|","36|","37|","38|","39|","40|","41|","42|","   ","   ","#\n"},
                                    {"##","###","###","###","###","###","###","###","###","###","###","###","###","#\n"}};
        //public IDictionary<int, int[]> placeLocationOnMap;
        private IDictionary<int, int[]> locOnMap = new Dictionary<int, int[]>()
        {
            {1, new int[]{2,1}},
            {2, new int[]{2,2}},
            {3, new int[]{2,3}},
            {4, new int[]{2,4}},
            {5, new int[]{2,5}},
            {6, new int[]{2,6}},
            {7, new int[]{2,7}},
            {8, new int[]{2,8}},
            {9, new int[]{2,9}},
            {10, new int[]{2,10}},
            {11, new int[]{2,11}},
            {12, new int[]{2,12}},

            {13, new int[]{4,1}},
            {14, new int[]{4,2}},
            {15, new int[]{4,3}},
            {16, new int[]{4,4}},
            {17, new int[]{4,5}},
            {18, new int[]{4,6}},
            {19, new int[]{4,7}},
            {20, new int[]{4,8}},
            {21, new int[]{4,9}},
            {22, new int[]{4,10}},

            {23, new int[]{8,1}},
            {24, new int[]{8,2}},
            {25, new int[]{8,3}},
            {26, new int[]{8,4}},
            {27, new int[]{8,5}},
            {28, new int[]{8,6}},
            {29, new int[]{8,7}},
            {30, new int[]{8,8}},
            {31, new int[]{8,9}},
            {32, new int[]{8,10}},

            {33, new int[]{10,1}},
            {34, new int[]{10,2}},
            {35, new int[]{10,3}},
            {36, new int[]{10,4}},
            {37, new int[]{10,5}},
            {38, new int[]{10,6}},
            {39, new int[]{10,7}},
            {40, new int[]{10,8}},
            {41, new int[]{10,9}},
            {42, new int[]{10,10}}        
        };

        public void displayMap()
        {
            Console.WriteLine("\t\tParking lot");
            foreach (var item in this.mapImg)
            {
                Console.Write(item);
            }
        }
        public string[,] getMap()
        {
            return this.mapImg;
        }
        public IDictionary<int, int[]> getLocOnMap()
        {
            return this.locOnMap;
        }
        public void changeToX(int slot)
        {
            this.mapImg[this.locOnMap[slot][0],this.locOnMap[slot][1]] = "XX|";
        }
        public void changeToEmpty(int slot)
        {
            this.mapImg[this.locOnMap[slot][0],this.locOnMap[slot][1]] = "  |";
        }
        public void clearAll()
        {
            for (int i = 1; i < 43; i++)
            {
                this.mapImg[this.locOnMap[i][0],this.locOnMap[i][1]] = "  |";
            }
        }
    
    }
    class ParkingPlace
    {
        private int number;
        private bool isFull;
        private DateTime timeReserved;
        private DateTime timeReleased;

        public ParkingPlace(int id)
        {
            this.number = id;
            this.isFull = false;
            this.timeReleased = DateTime.Now;
            this.timeReserved = DateTime.Now;
        }
        public bool getIsFull(){
            return this.isFull;
        }
        public DateTime getTimeReserved()
        {
            return this.timeReserved;
        }
        public DateTime getTimeReleased()
        {
            return this.timeReleased;
        }
        public void reserve(Map map){
            map.changeToX(this.number);
            this.isFull = true;
            this.timeReserved = DateTime.Now;
        }
        public void release(Map map){
            map.changeToEmpty(this.number);
            this.isFull = false;
            this.timeReleased = DateTime.Now;
        }
    }
}