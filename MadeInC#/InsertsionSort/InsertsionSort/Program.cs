using System.Diagnostics;

namespace InsertsionSort;

class Program
{
    static void Main(string[] args)
    {
        int[] theArray = new int[120000];
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
        /* In Insertsion Sort; the program checks at the array multiple times part by part as first 2 elements,
        first 3 elements, first 4 ... and all of the elements. In each checking, the program goes through each
        part starting from the second to last element of the part and goes to the first element. If the element
        that the program is checking is bigger than the last element of the part, it moves the last element of
        the part in front of the element that program is checking. This goes on like that until all of the
        elements are checked. */

        int temp;

        for (int i = 1; i < numberArray.Length; i++)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                if (numberArray[i] < numberArray[j])
                {
                    temp = numberArray[i];

                    for (int k = i; k > j; k--)
                    {
                        numberArray[k] = numberArray[k - 1];
                    }

                    numberArray[j] = temp;
                }
            }
        }
    }
}
