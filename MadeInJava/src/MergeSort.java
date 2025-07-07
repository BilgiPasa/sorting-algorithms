import java.util.Random;
//import java.util.Arrays; // Use this too if you want to see the array

public class MergeSort {
    public static void main(String[] args) {
        Random r = new Random();
        int[] theArray = new int[10000];

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

    static void Sort(int[] intArray)
    {
        if (intArray.length < 2)
        {
            return;
        }

        int middle = intArray.length / 2;
        int[] leftArray = new int[middle], rightArray = new int[intArray.length - middle];

        for (int i = 0; i < middle; i++)
        {
            leftArray[i] = intArray[i];
        }

        for (int i = middle; i < intArray.length; i++)
        {
            rightArray[i - middle] = intArray[i];
        }

        Sort(leftArray);
        Sort(rightArray);
        Merge(intArray, leftArray, rightArray);
    }

    public static void Merge(int[] intArray, int[] leftArray, int[] rightArray)
    {
        int i = 0, j = 0, k = 0;

        while (i < leftArray.length && j < rightArray.length)
        {
            if (leftArray[i] > rightArray[j])
            {
                intArray[k++] = rightArray[j++]; // This means intArray[k] = rightArray[j]; k += 1; j += 1;
            }
            else
            {
                intArray[k++] = leftArray[i++]; // This means intArray[k] = leftArray[i]; k += 1; i += 1;
            }
        }

        while (i < leftArray.length)
        {
            intArray[k++] = leftArray[i++]; // This means intArray[k] = leftArray[i]; k += 1; i += 1;
        }

        while (j < rightArray.length)
        {
            intArray[k++] = rightArray[j++]; // This means intArray[k] = rightArray[j]; k += 1; j += 1;
        }
    }
}
