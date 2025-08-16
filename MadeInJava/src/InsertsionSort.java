import java.util.Random;
//import java.util.Arrays; // Use this too if you want to see the array

public class InsertsionSort {
    public static void main(String[] args) {
        int[] theArray = new int[55555];
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
        /* In Insertsion Sort; the program checks at the array multiple times part by part as first 2 elements,
        first 3 elements, first 4 ... and all of the elements. In each checking, the program goes through each
        part starting from the second to last element of the part and goes to the first element. If the element
        that the program is checking is bigger than the last element of the part, it moves the last element of
        the part in front of the element that the program is checking. The sorting process ends when all of the
        elements are checked. */

        int temp;

        for (int i = 1; i < numberArray.length; i++)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                if (numberArray[i] < numberArray[j])
                {
                    temp = numberArray[i];

                    for (int k = i; k > j; k--) // Shifting the elements 1 to the left
                    {
                        numberArray[k] = numberArray[k - 1];
                    }

                    numberArray[j] = temp;
                }
            }
        }
    }
}
