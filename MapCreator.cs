using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace MapCreatorNamespace
{
    public class MapCreator
    {
        public int XAxis
        {get; set;}
        public int YAxis
        {get; set;}
        public int[] IndexLen
        {get; set;}
        public int[] yValues
        {get; set;}
        public int[] spaceNumDrawPos
        {get; set;}
        public int numOfSpaces
        {get; set;}

        private int rowCount;

        public MapCreator()
        {
            while (true)
            {
                string userInput;
                try
                {
                    Console.WriteLine("How many rows of parking spaces you wish to create");

                    userInput = Console.ReadLine();
                    this.rowCount = int.Parse(userInput);

                    this.IndexLen = new int[rowCount];
                    this.yValues = new int[rowCount];
                    this.spaceNumDrawPos = new int[rowCount];
                    break;

                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.\nPress enter to retry");
                    userInput = Console.ReadLine();
                    continue;

                }
                catch (System.ArgumentNullException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.\nPress enter to retry");
                    userInput = Console.ReadLine();
                    continue;

                }
            }

        }
        public void setupParams()
        {
            string userInput;
            try
            {
                Console.WriteLine("Provide number of parking spaces in rows");

                for (int i = 0; i < this.rowCount; i++)
                {
                    Console.Write($"Row nr {i+1}: ");
                    try
                    {
                        userInput = Console.ReadLine();
                        this.IndexLen[i] = int.Parse(userInput);
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Invalid input.\nPress any key to reenter value");
                        userInput = Console.ReadLine();
                        i = i -1;
                    }
                }
                this.XAxis = this.IndexLen.Max() +2;
                for (int i = 0; i < this.rowCount; i++)
                {
                    this.numOfSpaces += this.IndexLen[i];
                }
                Console.WriteLine("Choose parking spaces alignment.");
                Console.WriteLine("For back to back type \"b\"");
                Console.WriteLine("For facing one way type \"o\"");
                try
                {
                    userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "o":
                            this.calculateOnw();
                            break;
                        case "b":
                            this.calculateBtB();
                            break;
                        default:
                            Console.WriteLine("Wrong input, pres any key to return.");
                            userInput = Console.ReadLine();
                            Console.Clear();
                            break;
                            //continue;
                    } 
                }
                catch (System.Exception)
                {
                    
                    Console.WriteLine("Invalid input.\nPress any key to return");
                    userInput = Console.ReadLine();
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
        public void calculateBtB()
        {
            //i was originaly set to 6 for whatever reason
            int sub = 0;
            for (int i = 4; i <= this.rowCount+2; i=i+2)
            {
                if (this.rowCount < i)
                {
                    this.YAxis = this.rowCount*3 - sub +1;
                    break;
                }
                else
                {
                    ++sub;
                }   
            }

            int value = 2;
            int toAdd = 2;
            int space = -1;

            for (int i = 0; i < rowCount; i++)
            {
                if (space == -1)
                {
                    this.yValues[i] = value;
                    this.spaceNumDrawPos[i] = space;

                    value += toAdd;
                    toAdd = 3;
                    space = 1;
                }
                else
                {
                    this.yValues[i] = value;
                    this.spaceNumDrawPos[i] = space;

                    value += toAdd;
                    toAdd = 2;
                    space = -1;
                }
            }
        }
        public void calculateOnw()
        {
            this.YAxis = this.rowCount*3 +2;
            int value = 2;
            int toAdd = 3;
            int space = -1;

            for (int i = 0; i < rowCount; i++)
            {
                this.yValues[i] = value;
                this.spaceNumDrawPos[i] = space;
                value += toAdd;
            }
        }
        //testing
        public void printAll()
        {
            Console.Write($"y{this.YAxis} x{this.XAxis}\n");
            foreach (var item in this.IndexLen)
            {
                Console.Write($"{item}, ");
            }
            Console.Write("\n");
            foreach (var item in this.yValues)
            {
                Console.Write($"{item}, ");
            }
            Console.Write("\n");
            foreach (var item in this.spaceNumDrawPos)
            {
                Console.Write($"{item}, ");
            }
            Console.Write("\n");
        }
    }
}