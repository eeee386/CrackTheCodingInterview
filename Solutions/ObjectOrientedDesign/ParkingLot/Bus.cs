using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.ObjectOrientedDesign.ParkingLot
{
    class Bus: Vehicle
    {
        public ParkingSpotSizes Size { get; set; } = ParkingSpotSizes.Huge;
    }
}
