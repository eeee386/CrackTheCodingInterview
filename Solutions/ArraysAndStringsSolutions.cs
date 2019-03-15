using System;

namespace Solutions
{
    public class Solutions
    {
        public static bool IsRotatedString(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            string s1S1 = String.Concat(s1, s1);
            int counter = 0;

            foreach (char c in s1S1)
            {
                if (c != s2[counter])
                {
                    counter = 0;
                    continue;
                }

                counter++;
                if (counter == s1.Length)
                {
                    return true;
                }
            }
            return false;
        }
    }
}