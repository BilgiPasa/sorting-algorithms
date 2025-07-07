import java.util.Random;
//import java.util.Arrays; // Use this too if you want to see the array

public class BogoSort {
    public static void main(String[] args) {
        Random r = new Random();
        int[] theArray = new int[10]; // 10 is enough to show how much BogoSort is bad at sorting.

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
        boolean b = true;

        for (int i = 0; i < numberArray.length - 1; i++)
        {
            if (numberArray[i] > numberArray[i + 1])
            {
                b = false;
                break;
            }
        }

        if (!b)
        {
            Random r = new Random();
            int[] bogoSortedArray = new int[numberArray.length];

            while (!b)
            {
                b = true;
                int a = 0, temp;
                boolean[] didIUseThisElementForSelectingRandomlyArray = new boolean[numberArray.length];

                while (a < numberArray.length)
                {// I couldn't find a built in primitive integer array shuffler. So, here is my shuffler.
                    temp = r.nextInt(numberArray.length);

                    if (!didIUseThisElementForSelectingRandomlyArray[temp])
                    {
                        bogoSortedArray[a] = numberArray[temp];
                        didIUseThisElementForSelectingRandomlyArray[temp] = true;
                        a++;
                    }
                }

                for (int i = 0; i < numberArray.length - 1; i++)
                {
                    if (bogoSortedArray[i] > bogoSortedArray[i + 1])
                    {
                        b = false;
                        break;
                    }
                }
            }

            for (int i = 0; i < numberArray.length; i++)
            {
                numberArray[i] = bogoSortedArray[i];
            }
        }
    }
}
