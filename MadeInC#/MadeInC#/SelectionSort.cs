namespace MadeInC_;

class SelectionSort
{
    static void Main(string[] args)
    {
        Console.Write("Write me an integer array (split the numbers with comma) : ");
        string? arrayInText = Console.ReadLine();

        if (arrayInText == null)
        {
            Console.WriteLine("Bruh.");
            return;
        }

        string[] arrayInStringArray = arrayInText.Split(",");
        long[] theArray = new long[arrayInStringArray.Length];

        for (int i = 0; i < arrayInStringArray.Length; i++)
        {
            theArray[i] = Convert.ToInt64(arrayInStringArray[i].Trim());
        }

        theArray = Sort(theArray);
        Console.WriteLine("[{0}]", string.Join(", ", theArray));
    }

    static long[] Sort(long[] longArray)
    {
        int whatItLooked = 0;
        long smallest, temp;

        for (int a = 0; a < longArray.Length; a++)
        {
            smallest = longArray[a];

            for (int i = 0; i + a < longArray.Length; i++)
            {
                if (smallest >= longArray[i + a])
                {
                    smallest = longArray[i + a];
                    whatItLooked = i + a;
                }
            }

            temp = longArray[a];
            longArray[a] = longArray[whatItLooked];
            longArray[whatItLooked] = temp;
        }

        return longArray;
    }
}
