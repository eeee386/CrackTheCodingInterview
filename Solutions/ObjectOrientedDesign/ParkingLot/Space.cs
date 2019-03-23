using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.ObjectOrientedDesign.ParkingLot
{
    public class Space
    {
        public bool IsEmpty = false;
        public Vehicle vehicle = null;
        public ParkingSpotSizes Size;
        public int level;
        public int row;

        public Space(ParkingSpotSizes size)
        {
            Size = size;
        }

        public void Add(Vehicle vehicle)
        {
            if (vehicle.Size == Size)
            {
                this.vehicle = vehicle;
            }
        }
    }
}
