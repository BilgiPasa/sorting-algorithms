using System.Diagnostics;

namespace GnomeSort;

class Program
{
    static void Main(string[] args)
    {
        int[] theArray = new int[55555];
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
        /* In Gnome Sort, the program goes through the array from the start and checks the elements and the
        elements next to it. If the left element is bigger than the right element, the program swaps the
        elements and starts to go backwards. While going backwards, if the left element is bigger than the
        right next element, the program swaps the elements. When the program is at the start again, it starts
        to go forward and this process repeates until the program is at the end of the array. */

        int i = 1;
        bool forward = true;

        while (true)
        {
            while (forward)
            {
                if (i == numberArray.Length)
                {
                    return;
                }

                if (numberArray[i - 1] <= numberArray[i])
                {
                    i++;
                }
                else
                {
                    (numberArray[i - 1], numberArray[i]) = (numberArray[i], numberArray[i - 1]); // Swapping elements
                    forward = false;
                    break;
                }
            }

            while (!forward)
            {
                if (i == 1)
                {
                    forward = true;
                    break;
                }

                if (numberArray[i - 1] > numberArray[i])
                {
                    (numberArray[i - 1], numberArray[i]) = (numberArray[i], numberArray[i - 1]); // Swapping elements
                }

                i--;
            }
        }
    }
}
