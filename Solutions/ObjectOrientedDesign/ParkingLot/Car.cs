using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.ObjectOrientedDesign.ParkingLot
{
    class Car: Vehicle
    {
        public ParkingSpotSizes Size { get; set; } = ParkingSpotSizes.Large;
    }
}
