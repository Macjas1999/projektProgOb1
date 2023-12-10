using System;
using System.IO;
using System.Collections.Generic;

namespace MapTemplate
{
    public class Map
    {
        protected string[,] mapImg;
        protected int[] indexLen;
        protected int[] yValues;
        protected int[] spaceNumDrawPos;
        protected IDictionary<int, int[]> locOnMap = new Dictionary<int, int[]>();

        //#testing
        // public Map() //assuming 62 places
        // {
        //     this.mapImg = new string[20,14];
        //     this.indexLen = new int[] {12,10,10,10,10,10};
        //     this.yValues = new int[] {2,5,8,11,14,17};
        //     this.spaceNumDrawPos = new int[] {-1,-1,-1,-1,-1,-1};            
        // }
        // public Map() //assuming 62 places
        // {
        //     this.mapImg = new string[17,14];
        //     this.indexLen = new int[] {12,10,10,10,10,10};
        //     this.yValues = new int[] {2,4,7,9,12,14};
        //     this.spaceNumDrawPos = new int[] {-1,1,-1,1,-1,1};            
        // }
        //#!testing

        public Map()
        {}
        public Map(int yLen, int xlen, int[] indexLenIN, int[] yValuesIN, int[] spaceNumDrawPosIN)
        {
            this.mapImg = new string[yLen,xlen];
            this.indexLen = indexLenIN;
            this.yValues = yValuesIN;
            this.spaceNumDrawPos = spaceNumDrawPosIN;            
        }

        public virtual void makeFrame()
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
        public virtual void fillMapWSlots(int index, int xPos, int yPos, int extend)
        {
            this.mapImg[yPos,xPos] = "  |";
            if (index < 10)
            {
                this.mapImg[yPos+this.spaceNumDrawPos[extend], xPos] = $" {index}|";    
            }
            else
            {
                this.mapImg[yPos+this.spaceNumDrawPos[extend], xPos] = $"{index}|";
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

        public virtual void changeToX(int slot)
        {
            this.mapImg[this.locOnMap[slot][0],this.locOnMap[slot][1]] = "XX|";
        }
        public virtual void changeToEmpty(int slot)
        {
            this.mapImg[this.locOnMap[slot][0],this.locOnMap[slot][1]] = "  |";
        }

        public virtual void clearAll()
        {
            for (int i = 1; i < this.locOnMap.Count+1; i++)
            {
                this.mapImg[this.locOnMap[i][0],this.locOnMap[i][1]] = "  |";
            }
        }
        public void displayDict()
        {
            for (int i = 1; i < this.locOnMap.Count+1; i++)
            {
                Console.WriteLine($"{i};{this.locOnMap[i][0]};{this.locOnMap[i][1]}");
            }
        }
    }

    public class BigMap : Map
    {
        public BigMap()
        {}
        public BigMap(int yLen, int xlen, int[] indexLenIN, int[] yValuesIN, int[] spaceNumDrawPosIN)
        //public BigMap()
        {
            this.mapImg = new string[yLen,xlen];
            this.indexLen = indexLenIN;
            this.yValues = yValuesIN;
            this.spaceNumDrawPos = spaceNumDrawPosIN;            
        }

        public override void makeFrame()
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
                        this.mapImg[i,j] = "####";
                    }
                    else if(i == iLimit-1 && j < jLimit-1)
                    {
                        this.mapImg[i,j] = "####";
                    }
                    else if(j == jLimit-1)
                    {
                        this.mapImg[i,j] = "#\n";
                    }
                    else
                    {
                        this.mapImg[i,j] = "    ";
                    }
                }
            }
        }
        public override void fillMapWSlots(int index, int xPos, int yPos, int extend)
        {
            this.mapImg[yPos,xPos] = "   |";
            if (index < 10)
            {
                this.mapImg[yPos+this.spaceNumDrawPos[extend], xPos] = $"  {index}|";    
            }
            else if (index < 100)
            {
                this.mapImg[yPos+this.spaceNumDrawPos[extend], xPos] = $" {index}|";    
            }
            else
            {
                this.mapImg[yPos+this.spaceNumDrawPos[extend], xPos] = $"{index}|";
            }
        }
        public override void changeToX(int slot)
        {
            this.mapImg[this.locOnMap[slot][0],this.locOnMap[slot][1]] = "XXX|";
        }
        public override void changeToEmpty(int slot)
        {
            this.mapImg[this.locOnMap[slot][0],this.locOnMap[slot][1]] = "   |";
        }

        public override void clearAll()
        {
            for (int i = 1; i < this.locOnMap.Count+1; i++)
            {
                this.mapImg[this.locOnMap[i][0],this.locOnMap[i][1]] = "   |";
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
