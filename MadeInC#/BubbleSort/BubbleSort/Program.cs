using System.Diagnostics;

namespace BubbleSort;

class Program
{
    static void Main(string[] args)
    {
        Random r = new Random();
        Stopwatch s = new Stopwatch();
        int[] theArray = new int[12000000];

        for (int i = 0; i < theArray.Length; i++)
        {
            theArray[i] = r.Next(int.MinValue, int.MaxValue);
        }

        s.Start();
        theArray = Sort(theArray);
        s.Stop();
        //Console.WriteLine("[{0}]", string.Join(", ", theArray)); // To see the array
        Console.WriteLine($"{theArray.Length} integers sorted in {s.Elapsed.TotalMilliseconds} milliseconds");
    }

    static int[] Sort(int[] intArray)
    {
        int temp;
        bool b = true;

        while (!b)
        {
            b = true;

            for (int i = 0; i < intArray.Length - 1; i++)
            {
                if (intArray[i] > intArray[i + 1])
                {
                    temp = intArray[i];
                    intArray[i] = intArray[i + 1];
                    intArray[i + 1] = temp;
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

