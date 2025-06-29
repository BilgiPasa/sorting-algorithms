using System.Diagnostics;

namespace SelectionSort;

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
        Console.WriteLine($"{theArray.Length} integers sorted in {s.Elapsed.Milliseconds} milliseconds");
    }

    static int[] Sort(int[] intArray)
    {
        int smallest;

        for (int a = 0; a < intArray.Length - 1; a++)
        {
            smallest = a;

            for (int i = a; i < intArray.Length; i++)
            {
                if (intArray[smallest] > intArray[i])
                {
                    smallest = i;
                }
            }

            (intArray[a], intArray[smallest]) = (intArray[smallest], intArray[a]); // Swapping
        }

        return intArray;
    }
}
