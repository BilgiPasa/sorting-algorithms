import java.util.Random;
//import java.util.Arrays; // Use this too if you want to see the array

public class ShellSort {
    public static void main(String[] args) {
        int[] theArray = new int[12345678];
        Random r = new Random();

        for (int i = 0; i < theArray.length; i++)
        {
            theArray[i] = r.nextInt();
        }

        long startTime = System.nanoTime();
        sort(theArray);
        long endTime = System.nanoTime();
        //System.out.println(Arrays.toString(theArray)); // To see the array
        System.out.println(theArray.length + " integers sorted in " + ((endTime - startTime) / 1000000.0) + " milliseconds");
    }

    static void sort(int[] numberArray)
    {
        int temp, j;

        for (int interval = numberArray.length / 2; interval > 0; interval /= 2)
        {
            for (int i = interval; i < numberArray.length; i++)
            {
                temp = numberArray[i];

                for (j = i; j >= interval && numberArray[j - interval] > temp; j -= interval)
                {
                    numberArray[j] = numberArray[j - interval];
                }

                numberArray[j] = temp;
            }
        }
    }
}
