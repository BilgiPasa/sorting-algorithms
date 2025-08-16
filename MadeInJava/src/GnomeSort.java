import java.util.Random;
//import java.util.Arrays; // Use this too if you want to see the array

public class GnomeSort {
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
        /* In Gnome Sort, the program goes through the array from the start and checks the elements and the
        elements next to it. If the left element is bigger than the right element, the program swaps the
        elements and starts to go backwards. While going backwards, if the left element is bigger than the
        right next element, the program swaps the elements. When the program is at the start again, it starts
        to go forward and this process repeates until the program is at the end of the array. */

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
