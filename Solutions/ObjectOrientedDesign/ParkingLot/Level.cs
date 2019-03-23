using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.ObjectOrientedDesign.ParkingLot
{
    public class Level
    {
        public HashSet<Row> rows;

        public Level(HashSet<Row> rows)
        {
            this.rows = rows;
        }
    }
}
