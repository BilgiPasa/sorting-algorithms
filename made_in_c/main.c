#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <errno.h>
#include <limits.h>
#include <time.h>
#include "sorting_algorithms.h"

int get_int(int *num);

int main(void)
{
    enum AlgorithmTypes {
        BUBBLE_SORT,
        GNOME_SORT,
        SELECTION_SORT,
        INSERTION_SORT
        // TODO: IMPLEMENT MORE ALGORITHMS AND ADD THEM HERE.
    };

    enum AlgorithmTypes algorithm_type;
    printf("\nSorting algorithms (from slowest to fastest)\n");
    printf("1) Bubble Sort\n");
    printf("2) Gnome Sort\n");
    printf("3) Selection Sort\n");
    printf("4) Insertion Sort\n");
    printf("Select an algorithm: ");
    char algorithm_type_selection[1024];

    if (!fgets(algorithm_type_selection, sizeof(algorithm_type_selection), stdin))
    {
        printf("Couldn't understand the input. Aborting.");
        return 1;
    }

    int temp = atoi(algorithm_type_selection);

    if (temp > 4 || temp < 1)
    {
        printf("Couldn't understand the input. Aborting.\n");
        return 1;
    }

    algorithm_type = --temp; // This means temp -= 1; algorithm_type = temp;

    switch (algorithm_type)
    {
        case BUBBLE_SORT:
        case GNOME_SORT:
        case SELECTION_SORT:
        case INSERTION_SORT:
            printf("Enter the array size (55555 is recommended): ");
            break;

        default:
            printf("The algorithm type could not found. Aborting.\n");
            return 1;
    }

    int length;
    scanf("%d", &length); // TODO: MAKE A MORE SECURE INPUT LIKE YOU MADE AT ABOVE USING fgets.

    if (length < 0)
    {
        printf("The array size cannot be %d. Aborting.\n", length);
        return 1;
    }

    int number_array[length];
    printf("Starting to randomize the array.\n");
    srand((unsigned int)time(NULL));

    for (int i = 0; i < length; i++)
    {
        number_array[i] = rand(); // rand returns a random integer from 0 to INT_MAX (both 0 and INT_MAX are included)
    }

    printf("The array has randomized.\n");
    //print_array(number_array, length); // To see the array before sorting
    clock_t start, end;
    const char *used_algorithm_type;
    printf("Starting to sort the array.\n");

    switch (algorithm_type)
    {
        case BUBBLE_SORT:
            start = clock();
            bubble_sort(number_array, length);
            end = clock();
            used_algorithm_type = "Bubble Sort";
            break;

        case GNOME_SORT:
            start = clock();
            gnome_sort(number_array, length);
            end = clock();
            used_algorithm_type = "Gnome Sort";
            break;

        case SELECTION_SORT:
            start = clock();
            selection_sort(number_array, length);
            end = clock();
            used_algorithm_type = "Selection Sort";
            break;

        case INSERTION_SORT:
            start = clock();
            insertion_sort(number_array, length);
            end = clock();
            used_algorithm_type = "Insertion Sort";
            break;

        default:
            printf("The algorithm type could not found. Aborting.\n");
            return 1;
    }

    //print_array(number_array, length); // To see the array after sorting

    if (is_sorted(number_array, length))
    {
        printf("%d random integers has been sorted in %f milliseconds using %s.\n", length, ((double)(end - start) / CLOCKS_PER_SEC) * 1000, used_algorithm_type);
    }
    else
    {
        printf("The sorting algorithm ran but the array is not fully sorted.\n");
    }

    return 0;
}

// returns 1 on success and 0 on failure
// based on beginners' guide away from scanf()
int get_int(int *num)
{
    long a;
    char buf[1024];

    if (!fgets(buf, sizeof(buf), stdin))
    {
        // reading input failed
        return 0;
    }

    if (!strchr(buf, '\n')) {
        // fgets didn't covered the whole input
        // make sure we have empty input buffer before returning
        int c;
        while ((c = getchar()) != '\n' && c != EOF) { }

        return 0;
    }

    char *end_ptr;

    errno = 0; // reset error number

    a = strtol(buf, &end_ptr, 10);

    if (errno == ERANGE)
    {
        // input will not fit in a long
        return 0;
    }

    if (end_ptr == buf)
    {
        // no character was read
        return 0;
    }

    if (*end_ptr && *end_ptr != '\n')
    {
        // reading didn't convered the whole input
        return 0;
    }

    if (a > INT_MAX || a < INT_MIN)
    {
        // input will not fit in an int
        return 0;
    }

    *num = (int) a;
    return 1;
}
