import java.util.Random;
//import java.util.Arrays; // Use this too if you want to see the array

public class BozoSort {
    public static void main(String[] args) {
        int[] theArray = new int[12]; // 12 is enough to show how much Bozo Sort is bad at sorting.
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
        int i;
        boolean b = true;

        for (i = 1; i < numberArray.length; i++)
        {
            if (numberArray[i - 1] > numberArray[i])
            {
                b = false;
                break;
            }
        }

        if (b)
        {
            return;
        }

        int index1, index2, temp;
        Random r = new Random();

        while (!b)
        {
            b = true;

            do
            {
                index1 = r.nextInt(numberArray.length);
                index2 = r.nextInt(numberArray.length);
            }
            while (index1 == index2);

            temp = numberArray[index1];
            numberArray[index1] = numberArray[index2];
            numberArray[index2] = temp;

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