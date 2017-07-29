using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamApi
{
    class CTemplate
    {
        public static void DoTest()
        {
            int x = 2;
            int y = 5;

            int max = Maximum(x, y);
            Console.WriteLine("Maximum is " + max.ToString());
        } // end DoTest

        private static T Maximum<T>(T value1, T value2) where T : IComparable<T>
        {
            T maximumValue = value1;
            if (value2.CompareTo(maximumValue) > 0)
            {
                maximumValue = value2;
            }
            return (maximumValue);
        }

        private static void DisplayArray<T>(T[] array1)
        {
            foreach (T element in array1)
            {
                Console.WriteLine(element + " ");
            }

            Console.WriteLine("\n");
        }
    } // end class CTemplate
}
