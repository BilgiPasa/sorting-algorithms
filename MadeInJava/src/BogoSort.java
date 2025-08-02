import java.util.Random;
//import java.util.Arrays; // Use this too if you want to see the array

public class BogoSort {
    public static void main(String[] args) {
        int[] theArray = new int[11]; // Array size that bigger than 11 takes a looong time to sort.
        Random r = new Random();

        for (int i = 0; i < theArray.length; i++)
        {
            theArray[i] = r.nextInt();
        }

        long startTime = System.nanoTime();
        Sort(theArray);
        long endTime = System.nanoTime();
        //System.out.println(Arrays.toString(theArray)); // To see the array
        System.out.println(theArray.length + " integers sorted in " + ((endTime - startTime) / 1000000.0) + " milliseconds");
    }

    static void Sort(int[] numberArray)
    {
        /* In Bogo Sort; firstly, the program checks if the array is sorted. If not, it shuffels the array and
        checks again if the array is sorted. It continues this pattern until the array is sorted. */

        int i;
        boolean b = true;

        for (i = 1; i < numberArray.length; i++) // Cheking if the array is sorted
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

        int[] bogoSortedArray = new int[numberArray.length];
        int temp;
        Random r = new Random();

        while (!b)
        {
            i = 0;
            b = true;
            boolean[] didIUseThisElementForSelectingRandomlyArray = new boolean[numberArray.length];

            while (i < numberArray.length)
            {// I couldn't find a built in primitive integer array shuffler. So, here is my shuffler.
                temp = r.nextInt(numberArray.length);

                if (!didIUseThisElementForSelectingRandomlyArray[temp])
                {
                    bogoSortedArray[i++] = numberArray[temp]; // This means bogoSortedArray[i] = numberArray[temp]; i += 1;
                    didIUseThisElementForSelectingRandomlyArray[temp] = true;
                }
            }

            for (i = 1; i < numberArray.length; i++) // Cheking if the array is sorted
            {
                if (bogoSortedArray[i - 1] > bogoSortedArray[i])
                {
                    b = false;
                    break;
                }
            }
        }

        for (i = 0; i < numberArray.length; i++)
        {
            numberArray[i] = bogoSortedArray[i];
        }
    }
}
