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

        long startTime = System.currentTimeMillis();
        theArray = Sort(theArray);
        long endTime = System.currentTimeMillis();
        //System.out.println(Arrays.toString(theArray)); // To see the array
        System.out.println(theArray.length + " integers sorted in " + (endTime - startTime) + " milliseconds");
    }

    public static int[] Sort(int[] intArray)
    {
        boolean b = true;

        for (int i = 0; i < intArray.length - 1; i++)
        {
            if (intArray[i] > intArray[i + 1])
            {
                b = false;
                break;
            }
        }

        if (!b)
        {
            Random r = new Random();
            int[] bogoSortedArray = new int[intArray.length];

            while (!b)
            {
                b = true;
                int a = 0, temp;
                boolean[] didIUseThisElementForSelectingRandomlyArray = new boolean[intArray.length];

                while (a < intArray.length)
                {// I couldn't find a built in primitive integer array shuffler. So, here is my shuffler.
                    temp = r.nextInt(intArray.length);

                    if (!didIUseThisElementForSelectingRandomlyArray[temp])
                    {
                        bogoSortedArray[a] = intArray[temp];
                        didIUseThisElementForSelectingRandomlyArray[temp] = true;
                        a++;
                    }
                }

                for (int i = 0; i < intArray.length - 1; i++)
                {
                    if (bogoSortedArray[i] > bogoSortedArray[i + 1])
                    {
                        b = false;
                        break;
                    }
                }
            }

            return bogoSortedArray;
        }
        else
        {
            return intArray;
        }
    }
}
