import java.util.Random;
//import java.util.Arrays; // Use this too if you want to see the array

public class SelectionSort {
    public static void main(String[] args) {
        Random r = new Random();
        int[] theArray = new int[10000];

        for (int i = 0; i < theArray.length; i++)
        {
            theArray[i] = r.nextInt(Integer.MIN_VALUE, Integer.MAX_VALUE);
        }

        long start = System.currentTimeMillis();
        theArray = Sort(theArray);
        long end = System.currentTimeMillis();
        //System.out.println(Arrays.toString(theArray)); // To see the array
        System.out.println(theArray.length + " integers sorted in " + ((end - start) / 1000.0) + " seconds");
    }

    public static int[] Sort(int[] intArray)
    {
        int whatItLooked = 0, smallest, temp;

        for (int a = 0; a < intArray.length - 1; a++)
        {
            smallest = intArray[a];

            for (int i = 0; i + a < intArray.length; i++)
            {
                if (smallest >= intArray[i + a])
                {
                    smallest = intArray[i + a];
                    whatItLooked = i + a;
                }
            }

            temp = intArray[a];
            intArray[a] = intArray[whatItLooked];
            intArray[whatItLooked] = temp;
        }

        return intArray;
    }
}
