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

    }
}