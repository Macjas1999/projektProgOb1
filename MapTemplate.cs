using System;
using System.IO;
using System.Collections.Generic;

namespace MapTemplate
{
    public class Map
    {
        private string[,] mapImg;
        private int[] indexLen;
        private int[] yValues;
        private int[] numberSpaceDraw;
        private IDictionary<int, int[]> locOnMap = new Dictionary<int, int[]>();

        public Map(int xLen, int ylen)
        {
            this.mapImg = new string[xLen,ylen];
            this.indexLen = new int[] {12,10,10,10,10,10};
            this.yValues = new int[] {2,4,7,9,12,14};
            this.numberSpaceDraw = new int[] {-1,1,-1,1,-1,1};            
        }

        public void makeFrame()
        {
            int iLimit = this.mapImg.GetLength(0);
            int jLimit = this.mapImg.GetLength(1);
            for (int i = 0; i < iLimit; i++)
            {
                for (int j = 0; j < jLimit; j++)
                {
                    if(j == 0)
                    {
                        this.mapImg[i,j] = "#";
                    }
                    else if(i == 0 && j >= 0 && j < jLimit-1)
                    {
                        this.mapImg[i,j] = "###";
                    }
                    else if(i == iLimit-1 && j < jLimit-1)
                    {
                        this.mapImg[i,j] = "###";
                    }
                    else if(j == jLimit-1)
                    {
                        this.mapImg[i,j] = "#\n";
                    }
                    else
                    {
                        this.mapImg[i,j] = "   ";
                    }
                }
            }
        }
        //indexLim is lenght of desired deictionary plus one
        public void fillDictionary(int indexLim)
        {
            int xPos = 1;
            int run = 0;
            for (int i = 1; i < indexLim+1; i++)
            {
                if(xPos < this.indexLen[run])
                {
                    this.locOnMap.Add(i,new int[]{this.yValues[run],xPos});
                    fillMapWSlots(i, xPos, this.yValues[run], run);
                    xPos += 1;
                }
                else
                {
                    this.locOnMap.Add(i,new int[]{this.yValues[run],xPos});
                    fillMapWSlots(i, xPos, this.yValues[run], run);
                    run += 1;
                    xPos = 1;
                }
            }
        }
        public void fillMapWSlots(int index, int xPos, int yPos, int extend)
        {
            this.mapImg[yPos,xPos] = "  |";
            if (index < 10)
            {
                this.mapImg[yPos+this.numberSpaceDraw[extend], xPos] = $" {index}|";    
            }
            else
            {
                this.mapImg[yPos+this.numberSpaceDraw[extend], xPos] = $"{index}|";
            }
        }

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
        public void displayDict()
        {
            for (int i = 1; i < 43; i++)
            {
                Console.WriteLine($"{i};{this.locOnMap[i][0]};{this.locOnMap[i][1]}");
            }
        }
    }
    //Testing

    // class Program
    // {
    //     static void Main(string[] args)
    //     {
    //         Map map = new Map(13,14);
    //         map.makeFrame();
    //         map.fillDictionary(42);
    //         map.displayDict();
    //         map.displayMap();

    //     }
    // }
}
