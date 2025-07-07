using System.Diagnostics;

namespace BubbleSort;

class Program
{
    static void Main(string[] args)
    {
        Random r = new Random();
        Stopwatch s = new Stopwatch();
        int[] theArray = new int[10000];

        for (int i = 0; i < theArray.Length; i++)
        {
            theArray[i] = r.Next(int.MinValue, int.MaxValue);
        }

        s.Start();
        theArray = Sort(theArray);
        s.Stop();
        //Console.WriteLine("[{0}]", string.Join(", ", theArray)); // To see the array
        Console.WriteLine($"{theArray.Length} integers sorted in {s.Elapsed.TotalNanoseconds / 1000000} milliseconds");
    }

    static int[] Sort(int[] intArray)
    {
        bool b = false;

        while (!b)
        {
            b = true;

            for (int i = 0; i < intArray.Length - 1; i++)
            {
                if (intArray[i] > intArray[i + 1])
                {
                    (intArray[i], intArray[i + 1]) = (intArray[i + 1], intArray[i]);
                }
            }

            for (int i = 0; i < intArray.Length - 1; i++)
            {
                if (intArray[i] > intArray[i + 1])
                {
                    b = false;
                    break;
                }
            }
        }

        return intArray;
    }
}

