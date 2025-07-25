import java.util.Random;
//import java.util.Arrays; // Use this too if you want to see the array

public class SelectionSort {
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
        /* In Selection Sort, the program goes through the array and looks for the smallest element. When the
        array ends, it swaps the smallest element with the first element. Then it goes through the array again
        and looks for the second smallest element. When the array ends, it swaps the second smallest element
        with the second element and it goes on like that until the array is sorted. */

        int smallest, temp;

        for (int i = 0; i < numberArray.length - 1; i++)
        {
            smallest = i;

            for (int j = i; j < numberArray.length; j++)
            {
                if (numberArray[smallest] > numberArray[j])
                {
                    smallest = j;
                }
            }

            temp = numberArray[i];
            numberArray[i] = numberArray[smallest];
            numberArray[smallest] = temp;
        }
    }
}
