import java.util.Random;
//import java.util.Arrays; // Use this too if you want to see the array

public class CocktailShakerSort {
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
        /* You can think Cocktail Shaker Sort as double sided Bubble Sort. Cocktail Shaker Sort starts from the
        left side and moves to right like Bubble Sort but when it reaches the end, it moves to left. So the
        Cocktail Shaker Sort moves back and forth and swaps the elements if the left element is bigger than the
        right element. While swapping the elements, the smaller elements move to the left side and the bigger
        elements move to the right side. */

        int start = 0, end = numberArray.length - 1, i, temp;

        while (end - start > 1)
        {
            for (i = start; i < end; i++)
            {
                if (numberArray[i] > numberArray[i + 1])
                {
                    temp = numberArray[i];
                    numberArray[i] = numberArray[i + 1];
                    numberArray[i + 1] = temp;
                }
            }

            end--;

            for (i = end; i > start; i--)
            {
                if (numberArray[i - 1] > numberArray[i])
                {
                    temp = numberArray[i - 1];
                    numberArray[i - 1] = numberArray[i];
                    numberArray[i] = temp;
                }
            }

            start++;
        }
    }
}