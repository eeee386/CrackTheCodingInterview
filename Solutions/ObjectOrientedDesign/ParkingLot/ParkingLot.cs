using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions.ObjectOrientedDesign.ParkingLot
{
    class ParkingLot
    {
        public HashSet<Level> levels;

        public ParkingLot(HashSet<Level> levels)
        {
            this.levels = levels;
        }

        public void HandleNewVehicle(Vehicle vehicle)
        {
            Space freeSpace = null;

            foreach (var level in levels)
            {
                if (freeSpace != null) break;
                foreach (var row in level.rows)
                {
                    if (vehicle is Bus) {
                        int freeSpaceCounter = 0;
                        for(var i = 0; i < row.spaces.Count; i++)
                        {
                            if (row.spaces[i].IsEmpty && row.spaces[i].Size == ParkingSpotSizes.Large)
                            {
                                freeSpaceCounter++;
                                if(freeSpaceCounter == 5)
                                {
                                    for(int j = i-4; j < i; j++)
                                    {
                                        row.spaces[j].Add(vehicle);
                                    }
                                }
                            } else
                            {
                                freeSpaceCounter = 0;
                            }
                        }
                    } else
                    {
                        freeSpace = row.spaces.FirstOrDefault(s => s.IsEmpty && s.Size == vehicle.Size);
                    }
                    
                    if (freeSpace != null) break;
                }
            }
            if(freeSpace == null)
            {
                throw new Exception("Car cannot be added to the parking lot.");
            } else
            {
                freeSpace.Add(vehicle);
            }
        }
    }
}
