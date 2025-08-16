using System.Diagnostics;

namespace BozoSort;

class Program
{
    static void Main(string[] args)
    {
        int[] theArray = new int[12]; // Array size that bigger than 12 takes a looong time to sort.
        Random r = new Random();
        Stopwatch s = new Stopwatch();

        for (int i = 0; i < theArray.Length; i++)
        {
            theArray[i] = r.Next(int.MinValue, int.MaxValue);
        }

        s.Start();
        Sort(theArray);
        s.Stop();
        //Console.WriteLine("[{0}]", string.Join(", ", theArray)); // To see the array
        Console.WriteLine($"{theArray.Length} integers sorted in {s.Elapsed.TotalNanoseconds / 1000000} milliseconds");
    }

    static void Sort(int[] numberArray)
    {
        /* In Bozo Sort; firstly, the program checks if the array is sorted. If not, it selects two random
        items and swaps them. Then, it checks again if the array is sorted. The program repeates this process
        until the array is sorted. */

        int i;
        bool b = true;

        for (i = 1; i < numberArray.Length; i++) // Cheking if the array is sorted
        {
            if (numberArray[i - 1] > numberArray[i])
            {
                b = false;
                break;
            }
        }

        if (b)
        {
            return;
        }

        int index1, index2;
        Random r = new Random();

        while (!b)
        {
            b = true;

            do
            {
                index1 = r.Next(numberArray.Length);
                index2 = r.Next(numberArray.Length);
            }
            while (index1 == index2);

            (numberArray[index1], numberArray[index2]) = (numberArray[index2], numberArray[index1]); // Swapping elements

            for (i = 1; i < numberArray.Length; i++) // Cheking if the array is sorted
            {
                if (numberArray[i - 1] > numberArray[i])
                {
                    b = false;
                    break;
                }
            }
        }
    }
}
