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
        int i, temp;
        boolean b = false;

        while (!b)
        {
            b = true;

            for (i = 1; i < numberArray.length; i++)
            {
                if (numberArray[i - 1] > numberArray[i])
                {
                    temp = numberArray[i - 1];
                    numberArray[i - 1] = numberArray[i];
                    numberArray[i] = temp;
                }
            }

            for (i = 1; i < numberArray.length; i++)
            {
                if (numberArray[i - 1] > numberArray[i])
                {
                    b = false;
                    break;
                }
            }
        }
    }
}
