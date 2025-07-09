import java.util.Random;
//import java.util.Arrays; // Use this too if you want to see the array

public class GnomeSort {
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
        int i = 1, temp;
        boolean forward = true;

        while (true)
        {
            while (forward)
            {
                if (i == numberArray.length)
                {
                    return;
                }

                if (numberArray[i - 1] <= numberArray[i])
                {
                    i++;
                }
                else
                {
                    temp = numberArray[i - 1];
                    numberArray[i - 1] = numberArray[i];
                    numberArray[i] = temp;
                    forward = false;
                    break;
                }
            }

            while (!forward)
            {
                if (i == 1)
                {
                    forward = true;
                    break;
                }

                if (numberArray[i - 1] > numberArray[i])
                {
                    temp = numberArray[i - 1];
                    numberArray[i - 1] = numberArray[i];
                    numberArray[i] = temp;
                }

                i--;
            }
        }
    }
}
