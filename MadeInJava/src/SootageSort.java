import java.util.Random;
//import java.util.Arrays; // Use this too if you want to see the array

public class SootageSort {
    public static void main(String[] args) {
        int[] theArray = new int[4444]; // Yes, Sootage Sort is very inefficent too.
        Random r = new Random();

        for (int i = 0; i < theArray.length; i++)
        {
            theArray[i] = r.nextInt();
        }

        long startTime = System.nanoTime();
        sort(theArray, 0, theArray.length - 1);
        long endTime = System.nanoTime();
        //System.out.println(Arrays.toString(theArray)); // To see the array
        System.out.println(theArray.length + " integers sorted in " + ((endTime - startTime) / 1000000.0) + " milliseconds");
    }

    static void sort(int[] numberArray, int start, int end)
    {
        if (start == end)
        {
            return;
        }

        if (numberArray[start] > numberArray[end])
        {
            int temp = numberArray[start];
            numberArray[start] = numberArray[end];
            numberArray[end] = temp;
        }

        if (end - start > 1) // This means if (array size > 2)
        {
            int oneThird = (end - start + 1) / 3;
            sort(numberArray, start, end - oneThird);
            sort(numberArray, start + oneThird, end);
            sort(numberArray, start, end - oneThird);
        }
    }
}
