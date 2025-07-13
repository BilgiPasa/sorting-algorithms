import java.util.Random;
//import java.util.Arrays; // Use this too if you want to see the array

public class MergeSort {
    public static void main(String[] args) {
        Random r = new Random();
        int[] theArray = new int[120000];

        for (int i = 0; i < theArray.length; i++)
        {// I know that just using r.nextInt() includes Integer.MAX_VALUE. Becuz of that I made it like this.
            theArray[i] = r.nextInt(Integer.MIN_VALUE, Integer.MAX_VALUE);
        }

        long startTime = System.nanoTime();
        Sort(theArray);
        long endTime = System.nanoTime();
        //System.out.println(Arrays.toString(theArray)); // To see the array
        System.out.println(theArray.length + " integers sorted in " + ((endTime - startTime) / 1000000.0) + " milliseconds");
    }

    static void Sort(int[] numberArray)
    {
        if (numberArray.length < 2)
        {
            return;
        }

        int middle = numberArray.length / 2, i;
        int[] leftArray = new int[middle], rightArray = new int[numberArray.length - middle];

        for (i = 0; i < middle; i++)
        {
            leftArray[i] = numberArray[i];
        }

        for (i = middle; i < numberArray.length; i++)
        {
            rightArray[i - middle] = numberArray[i];
        }

        Sort(leftArray);
        Sort(rightArray);
        Merge(numberArray, leftArray, rightArray);
    }

    static void Merge(int[] numberArray, int[] leftArray, int[] rightArray)
    {
        int i = 0, j = 0, k = 0;

        while (i < leftArray.length && j < rightArray.length)
        {
            if (leftArray[i] > rightArray[j])
            {
                numberArray[k++] = rightArray[j++]; // This means numberArray[k] = rightArray[j]; k += 1; j += 1;
            }
            else
            {
                numberArray[k++] = leftArray[i++]; // This means numberArray[k] = leftArray[i]; k += 1; i += 1;
            }
        }

        while (i < leftArray.length)
        {
            numberArray[k++] = leftArray[i++]; // This means numberArray[k] = leftArray[i]; k += 1; i += 1;
        }

        while (j < rightArray.length)
        {
            numberArray[k++] = rightArray[j++]; // This means numberArray[k] = rightArray[j]; k += 1; j += 1;
        }
    }
}
