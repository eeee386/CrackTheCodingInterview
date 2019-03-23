using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.ObjectOrientedDesign.ParkingLot
{
    public interface Vehicle
    {
        ParkingSpotSizes Size { get; set; }
    }
}
