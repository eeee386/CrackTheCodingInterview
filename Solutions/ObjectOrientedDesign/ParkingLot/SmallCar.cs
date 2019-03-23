using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.ObjectOrientedDesign.ParkingLot
{
    class SmallCar: Vehicle
    {
        public ParkingSpotSizes Size { get; set; } = ParkingSpotSizes.Medium;
    }
}
