import java.util.Random;
//import java.util.Arrays; // Use this too if you want to see the array

public class InsertsionSort {
    public static void main(String[] args) {
        Random r = new Random();
        int[] theArray = new int[10000];

        for (int i = 0; i < theArray.length; i++)
        {// I know that just using r.nextInt() includes Integer.MAX_VALUE. Becuz of that I made it like this.
            theArray[i] = r.nextInt(Integer.MIN_VALUE, Integer.MAX_VALUE);
        }

        long startTime = System.nanoTime();
        theArray = Sort(theArray);
        long endTime = System.nanoTime();
        //System.out.println(Arrays.toString(theArray)); // To see the array
        System.out.println(theArray.length + " integers sorted in " + ((endTime - startTime) / 1000000.0) + " milliseconds");
    }

    static int[] Sort(int[] intArray)
    {
        int temp;

        for (int a = 1; a < intArray.length; a++)
        {
            for (int i = 0; i < a; i++)
            {
                if (intArray[a] < intArray[i])
                {
                    temp = intArray[a];

                    for (int j = a; j > i; j--)
                    {
                        intArray[j] = intArray[j - 1];
                    }

                    intArray[i] = temp;
                }
            }
        }

        return intArray;
    }
}
