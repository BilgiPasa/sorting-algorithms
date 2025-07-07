using System.Diagnostics;

namespace InsertsionSort;

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
        int temp;

        for (int a = 1; a < intArray.Length; a++)
        {
            for (int i = 0; i < a; i++)
            {
                if (intArray[a] < intArray[i])
                {
                    temp = intArray[a];

                    for (int j = a; j > i; j--)
                    {
                        intArray[j] = intArray[j - 1];
                    }

                    intArray[i] = temp;
                }
            }
        }

        return intArray;
    }
}
