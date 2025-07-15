import java.util.Random;
//import java.util.Arrays; // Use this too if you want to see the array

public class ShellSort {
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
        int temp, j;

        for (int gap = numberArray.length / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < numberArray.length; i++)
            {
                temp = numberArray[i];

                for (j = i; j >= gap && numberArray[j - gap] > temp; j -= gap)
                {
                    numberArray[j] = numberArray[j - gap];
                }

                numberArray[j] = temp;
            }
        }
    }
}
