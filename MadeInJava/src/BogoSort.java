import java.util.Random;
//import java.util.Arrays; // Use this too if you want to see the array

public class BogoSort {
    public static void main(String[] args) {
        int[] theArray = new int[12]; // 12 is enough to show how much Bogo Sort is bad at sorting.
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
        int i;
        boolean b = true;

        for (i = 1; i < numberArray.length; i++)
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
        int j, temp;
        Random r = new Random();

        while (!b)
        {
            j = 0;
            b = true;
            boolean[] didIUseThisElementForSelectingRandomlyArray = new boolean[numberArray.length];

            while (j < numberArray.length)
            {// I couldn't find a built in primitive integer array shuffler. So, here is my shuffler.
                temp = r.nextInt(numberArray.length);

                if (!didIUseThisElementForSelectingRandomlyArray[temp])
                {
                    bogoSortedArray[j++] = numberArray[temp]; // This means bogoSortedArray[j] = numberArray[temp]; j += 1;
                    didIUseThisElementForSelectingRandomlyArray[temp] = true;
                }
            }

            for (i = 1; i < numberArray.length; i++)
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
