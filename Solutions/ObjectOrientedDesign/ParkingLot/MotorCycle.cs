using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.ObjectOrientedDesign.ParkingLot
{
    class MotorCycle: Vehicle
    {
        public ParkingSpotSizes Size { get; set; } = ParkingSpotSizes.Small;
    }
}
