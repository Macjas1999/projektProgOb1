using System;
using System.IO;
using System.Collections.Generic;
using MapTemplate;

namespace ParkingPlaceNamespace
{
    public class ParkingPlace
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