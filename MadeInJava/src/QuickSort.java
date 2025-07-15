import java.util.Random;
//import java.util.Arrays; // Use this too if you want to see the array

public class QuickSort {
    public static void main(String[] args) {
        int[] theArray = new int[120000];
        Random r = new Random();

        for (int i = 0; i < theArray.length; i++)
        {
            theArray[i] = r.nextInt();
        }

        long startTime = System.nanoTime();
        Sort(theArray, 0, theArray.length - 1);
        long endTime = System.nanoTime();
        //System.out.println(Arrays.toString(theArray)); // To see the array
        System.out.println(theArray.length + " integers sorted in " + ((endTime - startTime) / 1000000.0) + " milliseconds");
    }

    static void Sort(int[] numberArray, int start, int end)
    {
        if (start >= end)
        {
            return;
        }

        int pivot = MoveElementsAndReturnPivot(numberArray, start, end);
        Sort(numberArray, start, pivot - 1);
        Sort(numberArray, pivot + 1, end);
    }

    static int MoveElementsAndReturnPivot(int[] numberArray, int start, int end)
    {
        int i = start - 1, temp;

        for (int j = start; j < end; j++)
        {// Initial pivot is the last element of the array
            // Moving elements that is smaller than our pivot to the left.
            if (numberArray[j] < numberArray[end])
            {
                temp = numberArray[++i]; // This means i += 1; temp = numberArray[i];
                numberArray[i] = numberArray[j];
                numberArray[j] = temp;
            }
        }

        temp = numberArray[++i]; // This means i += 1; temp = numberArray[i];
        numberArray[i] = numberArray[end];
        numberArray[end] = temp;
        return i; // Swapped the initial pivot with our new pivot and returned the new pivot
    }
}
