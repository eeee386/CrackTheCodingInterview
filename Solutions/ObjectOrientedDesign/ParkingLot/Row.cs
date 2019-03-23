using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.ObjectOrientedDesign.ParkingLot
{
    public class Row
    {
        public List<Space> spaces;

        public Row(List<Space> spaces)
        {
            this.spaces = spaces;
        }
    }
}
