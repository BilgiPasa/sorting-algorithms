using System.Diagnostics;

namespace SelectionSort;

class Program
{
    static void Main(string[] args)
    {
        Random r = new Random();
        Stopwatch s = new Stopwatch();
        int[] theArray = new int[5000];

        for (int i = 0; i < theArray.Length; i++)
        {
            theArray[i] = r.Next(int.MinValue, int.MaxValue);
        }

        s.Start();
        theArray = Sort(theArray);
        s.Stop();
        //Console.WriteLine("[{0}]", string.Join(", ", theArray)); // To see the array
        Console.WriteLine($"{theArray.Length} integers sorted in {s.Elapsed.TotalSeconds} seconds");
    }

    static int[] Sort(int[] intArray)
    {
        int whatItLooked = 0, smallest, temp;

        for (int a = 0; a < intArray.Length; a++)
        {
            smallest = intArray[a];

            for (int i = 0; i + a < intArray.Length; i++)
            {
                if (smallest >= intArray[i + a])
                {
                    smallest = intArray[i + a];
                    whatItLooked = i + a;
                }
            }

            temp = intArray[a];
            intArray[a] = intArray[whatItLooked];
            intArray[whatItLooked] = temp;
        }

        return intArray;
    }
}
