using System;
using System.IO;
using System.Collections.Generic;
using MapTemplate;

namespace ParkingPlaceNamespace
{
    public class ParkingPlace
    {
        protected int number;
        protected bool isFull;
        protected DateTime timeReserved;
        protected DateTime timeReleased;

        public ParkingPlace()
        {}

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
    public class BigParkingPlace : ParkingPlace
    {
        public BigParkingPlace()
        {}
        public BigParkingPlace(int id)
        //public BigParkingPlace()
        {
            this.number = id;
            this.isFull = false;
            this.timeReleased = DateTime.Now;
            this.timeReserved = DateTime.Now;
        }
        public void reserve(BigMap map){
            map.changeToX(this.number);
            this.isFull = true;
            this.timeReserved = DateTime.Now;
        }
        public void release(BigMap map){
            map.changeToEmpty(this.number);
            this.isFull = false;
            this.timeReleased = DateTime.Now;
        }
    }
}