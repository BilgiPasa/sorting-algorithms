import java.util.Random;
//import java.util.Arrays; // Use this too if you want to see the array

public class InsertsionSort {
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
        int temp;

        for (int i = 1; i < numberArray.length; i++)
        {
            for (int j = 0; j < i; j++)
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
