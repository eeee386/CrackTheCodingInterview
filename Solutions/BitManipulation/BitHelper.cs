using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Solutions.TreesAndGraphs;

namespace Solutions.BitManipulation
{
    public class Bit
    {
        public int value;

        public Bit(int value)
        {
            this.value = value;
        }

        public int GetBitAtPosition(int position)
        {
            return (value & (1 << position)) != 0 ? 1 : 0;
        }

        public int SetBit(int position)
        {
            return value | (1 << position);
        }

        public int ClearBit(int position)
        {
            return value & ~(1 << position);
        }

        public int UpdateBit(int i, int bit)
        {
            int val = bit != 0 ? 1 : 0;
            int mask = ~(1 << i);
            return (value & mask) | val << i;
        }

        public static int Insertion(int n, int m, int i, int j)
        {
            Bit nHelper = new Bit(n);
            Bit mHelper = new Bit(m);
            for (int k = j; j > i; j--)
            {
                nHelper.ClearBit(k);
            }

            for (int g = j; j > i; j--)
            {
                nHelper.UpdateBit(g, mHelper.GetBitAtPosition(g));
            }

            return nHelper.value;
        }

        public static string DoubleFractionToBinaryString(double d)
        {
            if (d > 1 || d <= 0)
            {
                throw new Exception("It is not a fraction number");
            }
            StringBuilder s = new StringBuilder("0.");
            double r;
            while (d > 0)
            {
                r = d * 2;
                if (r >= 1)
                {
                    s.Append('1');
                    d = r - 1;
                }
                else
                {
                    s.Append('0');
                    d = r;
                }
            }

            return s.ToString();
        }

        public int FindLongestSequenceOfFlipped()
        {
            if (~value == 0)
            {
                return new BitArray(value).Length;
            }

            int currentLength = 0;
            int prevLength = 0;
            int maxLength = 1;

            int r = value;
            
            while (r != 0)
            {
                if ((r & 1) == 1)
                {
                    currentLength++;
                }
                else
                {
                    prevLength = (r & 1) == 0 ? 0 : currentLength;
                    currentLength = 0;
                }

                maxLength = Math.Max(prevLength + maxLength + 1, maxLength);
                r = r >> 1;
            }

            return maxLength;
        }

        public int FindNextLargestOfBits()
        {
            int c = 0;
            int c0 = 0;
            int c1 = 0;

            while ((c & 1) == 0 && (c != 0))
            {
                c0++;
                c = c >> 1;
            }

            while ((c & 1) == 1)
            {
                c1++;
                c = c >> 1;
            }

            if (c0 + c1 == 31 || c0 + c1 == 0)
            {
                return value;
            }

            int p = c0 + c1;

            int bigger = value;
            bigger |= 1 << p;
            bigger &= ~((1 << p) - 1);
            bigger |= (1 << (c1 - 1) - 1);
            return bigger;

        }

        public int FindNextSmallestOfBits()
        {
            int temp = value;
            int c0 = 0;
            int c1 = 0;
            while ((temp & 1) == 1)
            {
                c1++;
                temp = temp >> 1;
            }

            if (temp == 0)
            {
                return value;
            }

            while ((temp & 1) == 0 && (temp != 0))
            {
                c0++;
                temp = temp >> 1;
            }

            int p = c0 + c1;
            int smaller = value;
            smaller &= ~0 << (p + 1);
            int mask = 1 << (c1 + 1) - 1;
            smaller |= mask << (c0 - 1);

            return smaller;
        }


        public static int Conversion(int n1, int n2)
        {
            int count = 0;
            for (int c = n1 ^ n2; c != 0; c = c >> 1)
            {
                count += c & 1;
            }

            return count;
        }


        public int PairwiseSwap()
        {
            const int mask = 0xAAAAAAA;
            return (value & mask) >> 1 | (value & ~mask) << 1;
        }

        public static void DrawLine(byte[] screen, int width, int x1, int x2, int y)
        {
            if (width % 8 != 0)
            {
                throw new Exception("Width is not dividable by 8!");
            }

            int height = screen.Length / (width / 8);

            int fullBytesInWidth = screen.Length / height;

            if (x1 < 0 || x2 > fullBytesInWidth * 8)
            {
                throw new Exception("This is not a valid pixel");
            }

            int lineStartOffSet = x1 % 8;
            int lineStartOfByteArray = x1 / 8;


            int lineEndOffSet = x2 % 8;
            int lineEndOfByteArray = x2 / 8;

            if (lineEndOfByteArray - lineStartOfByteArray >= fullBytesInWidth)
            {
                throw new Exception("This will not be a horizontal line.");
            }
            
            int byteArrayIndexOne = (y - 1) * fullBytesInWidth + lineStartOfByteArray;
            int byteArrayIndexTwo = (y - 1) * fullBytesInWidth + lineEndOfByteArray;
            
            byte startingArray = screen[byteArrayIndexOne];
            byte endingArray = screen[byteArrayIndexTwo];

            if (lineStartOffSet != 0)
            {
                for (int i = 0; i < lineStartOffSet; i++)
                {
                    int newStartingArray = startingArray | (1 << i);
                    if (newStartingArray > Byte.MaxValue)
                    {
                        throw new Exception("Not a valid number");
                    }
                    startingArray = (byte) newStartingArray;
                }
                screen[byteArrayIndexOne] = startingArray;
            }

            for (int j = byteArrayIndexOne + 1; j < byteArrayIndexTwo; j++)
            {
                screen[j] = Byte.MaxValue;
            }

            if (lineEndOffSet != 0)
            {
                for (int k = 8 - lineEndOffSet; k < 8; k++)
                {
                    int newEndingArray = endingArray | (1 << k);
                    if (newEndingArray > Byte.MaxValue)
                    {
                        throw new Exception("Not a valid number");
                    }
                    endingArray = (byte) newEndingArray;
                }

                screen[byteArrayIndexTwo] = endingArray;
            }

            for (int i = 0; i < screen.Length; i++)
            {
                if (i % fullBytesInWidth == 0)
                {
                    Console.WriteLine();
                }
                Console.Write(Convert.ToString(screen[i], 2));
                Console.Write(' ');
            }
        }
        
        
    }
}