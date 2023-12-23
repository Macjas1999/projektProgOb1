using System;
using System.Collections.Generic;
using MapTemplate;
using MainControlNamespace;
using ParkingPlaceNamespace;
using MapCreatorNamespace;
using System.IO;

namespace MainContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runNew = true;
            while (runNew)
            {
                MapCreator mapCreator = new MapCreator();
                mapCreator.setupParams();
            
                ParkingPlace[] parkingPlaces;
                Map map;

                if (mapCreator.numOfSpaces < 100)
                {
                    map = new Map(mapCreator.YAxis, mapCreator.XAxis, mapCreator.IndexLen, mapCreator.yValues, mapCreator.spaceNumDrawPos);
                    parkingPlaces = new ParkingPlace[mapCreator.numOfSpaces];
                    for (int i = 0; i < parkingPlaces.Length; i++)
                    {
                        parkingPlaces[i] = new ParkingPlace(i+1);
                    }
                }
                else
                {
                    map = new BigMap(mapCreator.YAxis, mapCreator.XAxis, mapCreator.IndexLen, mapCreator.yValues, mapCreator.spaceNumDrawPos);
                    parkingPlaces = new BigParkingPlace[mapCreator.numOfSpaces];
                    for (int i = 0; i < parkingPlaces.Length; i++)
                    {
                        parkingPlaces[i] = new BigParkingPlace(i+1);
                    }
                }
                //Map map = new Map(mapCreator.YAxis, mapCreator.XAxis, mapCreator.IndexLen, mapCreator.yValues, mapCreator.spaceNumDrawPos);

                MainControl ctrl = new MainControl();
                map.makeFrame();
                map.fillDictionary(mapCreator.numOfSpaces);

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
                    Console.WriteLine("To create new map type \"new\"");
                    Console.WriteLine("To exit type \"exit\"");

                    string userInput = Console.ReadLine();
                    switch (userInput)
                    {

                        case "res":
                            ctrl.resOption(map, parkingPlaces, userInput);
                            break;
                        case "emp":
                            ctrl.empOption(map, parkingPlaces, userInput);
                            break;
                        case "tout":
                            ctrl.toutOption(map, parkingPlaces, userInput);
                            break;
                        case "tin":
                            ctrl.tinOption(map, parkingPlaces, userInput);
                            break;
                        case "new":
                            run = false;
                            break;
                        case "exit":
                            runNew = false;
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
    }
}