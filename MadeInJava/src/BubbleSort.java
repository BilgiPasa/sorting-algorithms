import java.util.Random;
//import java.util.Arrays; // Use this too if you want to see the array

public class BubbleSort {
    public static void main(String[] args) {
        int[] theArray = new int[120000];
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
        /* In Bubble Sort, the program goes through the array and checks the elements and the elements next to
        it. If the left element that program is checking is bigger than the right next element, the program
        swaps the elements. When the array ends, if the array is not sorted, the program repeats this process
        until the array is sorted. */

        int i, j, temp;

        do
        {
            i = 0;

            for (j = 1; j < numberArray.length; j++)
            {
                if (numberArray[j - 1] > numberArray[j])
                {
                    temp = numberArray[j - 1];
                    numberArray[j - 1] = numberArray[j];
                    numberArray[j] = temp;
                    i++;
                }
            }
        }
        while (i > 0);
    }
}
