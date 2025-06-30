using System.Diagnostics;

namespace BogoSort;

class Program
{
    static void Main(string[] args)
    {
        Random r = new Random();
        Stopwatch s = new Stopwatch();
        int[] theArray = new int[10]; // 10 is enough to show how much BogoSort is bad at sorting.

        for (int i = 0; i < theArray.Length; i++)
        {
            theArray[i] = r.Next(int.MinValue, int.MaxValue);
        }

        s.Start();
        theArray = Sort(theArray);
        s.Stop();
        //Console.WriteLine("[{0}]", string.Join(", ", theArray)); // To see the array
        Console.WriteLine($"{theArray.Length} integers sorted in {s.ElapsedMilliseconds} milliseconds");
    }

    static int[] Sort(int[] intArray)
    {
        bool b = true;

        for (int i = 0; i < intArray.Length - 1; i++)
        {
            if (intArray[i] > intArray[i + 1])
            {
                b = false;
                break;
            }
        }

        if (!b)
        {
            Random r = new Random();

            while (!b)
            {
                b = true;
                r.Shuffle(intArray);

                for (int i = 0; i < intArray.Length - 1; i++)
                {
                    if (intArray[i] > intArray[i + 1])
                    {
                        b = false;
                        break;
                    }
                }
            }
        }

        return intArray;
    }
}
