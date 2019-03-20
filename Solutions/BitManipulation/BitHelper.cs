using System;
using System.Collections;
using System.Collections.ObjectModel;

namespace Solutions.BitManipulation
{
    public class Bit
    {
        public byte value;

        public Bit(byte value)
        {
            this.value = value;
        }

        public bool GetBitAtPosition(int position)
        {
            return (value & (1 << position)) != 0;
        }

        public int SetBit(int position)
        {
            return value | (1 << position);
        }

        public int ClearBit(int position)
        {
            return value & ~(1 << position);
        }

        public int UpdateBit(int i, bool bit)
        {
            int val = bit ? 1 : 0;
            int mask = ~(1 << i);
            return (value & mask) | val << i;
        }

    }
}u