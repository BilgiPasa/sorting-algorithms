using System.Diagnostics;

namespace BogoSort;

class Program
{
    static void Main(string[] args)
    {
        Random r = new Random();
        Stopwatch s = new Stopwatch();
        int[] theArray = new int[12]; // 12 is more than enough to show how much BogoSort is bad at sorting.

        for (int i = 0; i < theArray.Length; i++)
        {
            theArray[i] = r.Next(int.MinValue, int.MaxValue);
        }

        s.Start();
        theArray = Sort(theArray);
        s.Stop();
        //Console.WriteLine("[{0}]", string.Join(", ", theArray)); // To see the array
        Console.WriteLine($"{theArray.Length} integers sorted in {s.Elapsed.Seconds} seconds");
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
            int[] bogoSortedArray = new int[intArray.Length];

            while (!b)
            {
                b = true;
                int a = 0, temp;
                bool[] didIUseThisElementForSelectingRandomlyArray = new bool[intArray.Length];

                while (a < intArray.Length)
                {
                    temp = r.Next(intArray.Length);

                    if (!didIUseThisElementForSelectingRandomlyArray[temp])
                    {
                        bogoSortedArray[a] = intArray[temp];
                        didIUseThisElementForSelectingRandomlyArray[temp] = true;
                        a++;
                    }
                }

                for (int i = 0; i < intArray.Length - 1; i++)
                {
                    if (bogoSortedArray[i] > bogoSortedArray[i + 1])
                    {
                        b = false;
                        break;
                    }
                }
            }

            return bogoSortedArray;
        }
        else
        {
            return intArray;
        }
    }
}
