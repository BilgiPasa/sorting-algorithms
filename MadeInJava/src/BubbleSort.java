import java.util.Random;
//import java.util.Arrays; // Use this too if you want to see the array

public class BubbleSort {
    public static void main(String[] args) {
        Random r = new Random();
        int[] theArray = new int[10000];

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
        int temp;
        boolean b = false;

        while (!b)
        {
            b = true;

            for (int i = 0; i < intArray.length - 1; i++)
            {
                if (intArray[i] > intArray[i + 1])
                {
                    temp = intArray[i];
                    intArray[i] = intArray[i + 1];
                    intArray[i + 1] = temp;
                }
            }

            for (int i = 0; i < intArray.length - 1; i++)
            {
                if (intArray[i] > intArray[i + 1])
                {
                    b = false;
                    break;
                }
            }
        }

        return intArray;
    }
}
