import java.util.Arrays;
import java.util.Scanner;

public class SelectionSort {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.print("Write me an integer array (split the numbers with comma): ");
        String arrayInText = input.nextLine();
        input.close();
        String[] arrayInStringArray = arrayInText.split(",");
        long[] theArray = new long[arrayInStringArray.length];

        for (int i = 0; i < arrayInStringArray.length; i++)
        {
            theArray[i] = Long.parseLong(arrayInStringArray[i].trim());
        }

        theArray = Sort(theArray);
        System.out.println(Arrays.toString(theArray));
    }

    public static long[] Sort(long[] longArray)
    {
        int whatItLooked = 0;
        long smallest, temp;

        for (int a = 0; a < longArray.length; a++)
        {
            smallest = longArray[a];

            for (int i = 0; i + a < longArray.length; i++)
            {
                if (smallest >= longArray[i + a])
                {
                    smallest = longArray[i + a];
                    whatItLooked = i + a;
                }
            }

            temp = longArray[a];
            longArray[a] = longArray[whatItLooked];
            longArray[whatItLooked] = temp;
        }

        return longArray;
    }
}
