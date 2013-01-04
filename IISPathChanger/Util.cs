using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IISPathChanger
{
    public class Util
    {
        private static readonly Random Random = new Random((int)DateTime.Now.Ticks);

        public static string RandId()
        {
            return RandomString(8);
        }

        private static string RandomString(int size)
        {
            var builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * Random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
}
