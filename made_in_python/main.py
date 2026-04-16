from enum import IntEnum
from random import randint
from sorting_algorithms import is_sorted, quick_sort, merge_sort, shell_sort, insertion_sort, selection_sort, gnome_sort, cocktail_shaker_sort, bubble_sort, sootage_sort, bozo_sort, bogo_sort
from time import time

class AlgorithmTypes(IntEnum):
    BUILT_IN = 0
    QUICK_SORT = 1
    MERGE_SORT = 2
    SHELL_SORT = 3
    INSERTION_SORT = 4
    SELECTION_SORT = 5
    GNOME_SORT = 6
    COCKTAIL_SHAKER_SORT = 7
    BUBBLE_SORT = 8
    SOOTAGE_SORT = 9
    BOZO_SORT = 10
    BOGO_SORT = 11

def main() -> None:
    print()
    print("Sorting algorithms (from fastest to slowest)")
    print("1) Quick Sort")
    print("2) Merge Sort")
    print("3) Shell Sort")
    print("4) Insertion Sort")
    print("5) Selection Sort")
    print("6) Gnome Sort")
    print("7) Cocktail Shaker Sort")
    print("8) Bubble Sort")
    print("9) Sootage Sort")
    print("10) Bozo Sort")
    print("11) Bogo Sort")
    selected_algorithm: int

    try:
        selected_algorithm = int(input("Select an algorithm: "))
    except:
        print("Couldn't understand the input. Aborting.")
        return

    match selected_algorithm:
        case AlgorithmTypes.BUILT_IN:
            print("Enter the list size (12345678 is recommended): ", end="")

        case AlgorithmTypes.QUICK_SORT | AlgorithmTypes.MERGE_SORT | AlgorithmTypes.SHELL_SORT:
            print("Enter the list size (1234567 is recommended): ", end="")

        case AlgorithmTypes.INSERTION_SORT | AlgorithmTypes.SELECTION_SORT | AlgorithmTypes.GNOME_SORT | AlgorithmTypes.COCKTAIL_SHAKER_SORT | AlgorithmTypes.BUBBLE_SORT:
            print("Enter the list size (12345 is recommended): ", end="")

        case AlgorithmTypes.SOOTAGE_SORT:
            print("Enter the list size (2222 is recommended): ", end="")

        case AlgorithmTypes.BOZO_SORT | AlgorithmTypes.BOGO_SORT:
            print("Enter the list size (12 is recommended): ", end="")

        case _:
            print("Couldn't understand the input. Aborting.")
            return

    # Why the recommended values are smaller compared to C, C# and Java? Because Python is SLOW. I am not joking.
    # But fortunately, Python's built-in sorter is fast enough.

    length: int

    try:
        length = int(input())
    except:
        print("Wrong input. Aborting.")
        return

    MAX_VALUE: int = 2147483647 # 32-bit signed integer max value

    if length == 0:
        print("Don't make the list size as 0. Aborting.")
        return
    elif length > MAX_VALUE:
        print("Don't make the list size more than MAX_VALUE. Aborting.")
        return
    elif length < 0:
        print("Don't try to make the list size as a negative integer. Aborting.")
        return

    num_list: list[int]

    try:
        num_list = [0] * length
    except:
        print("The list size cannot be " + str(length) + ". Aborting.")
        return

    print("Starting to randomize the list.")

    # Python's integer is 64 bit. Because of that I made the randomizer like this.
    for i in range(len(num_list)):
        # Note: the randint function includes both end points.
        num_list[i] = randint(0, MAX_VALUE)
        # Don't forget to write MAX_VALUE as the endpoint.

    print("The list has randomized.")
    #print("[" + ", ".join(str(x) for x in num_list) + "]") # To see the list before sorting
    start_time: float
    end_time: float
    used_algorithm_type: str
    print("Starting to sort the list.")

    match selected_algorithm:
        case AlgorithmTypes.BUILT_IN:
            used_algorithm_type = "Python's built-in sorter"
            start_time = time()
            num_list = sorted(num_list)
            end_time = time()

        case AlgorithmTypes.QUICK_SORT:
            used_algorithm_type = "Quick Sort"
            start_time = time()
            quick_sort(num_list, 0, len(num_list) - 1)
            end_time = time()

        case AlgorithmTypes.MERGE_SORT:
            used_algorithm_type = "Merge Sort"
            start_time = time()
            merge_sort(num_list)
            end_time = time()

        case AlgorithmTypes.SHELL_SORT:
            used_algorithm_type = "Shell Sort"
            start_time = time()
            shell_sort(num_list)
            end_time = time()

        case AlgorithmTypes.INSERTION_SORT:
            used_algorithm_type = "Insertion Sort"
            start_time = time()
            insertion_sort(num_list)
            end_time = time()

        case AlgorithmTypes.SELECTION_SORT:
            used_algorithm_type = "Selection Sort"
            start_time = time()
            selection_sort(num_list)
            end_time = time()

        case AlgorithmTypes.GNOME_SORT:
            used_algorithm_type = "Gnome Sort"
            start_time = time()
            gnome_sort(num_list)
            end_time = time()

        case AlgorithmTypes.COCKTAIL_SHAKER_SORT:
            used_algorithm_type = "Cocktail Shaker Sort"
            start_time = time()
            cocktail_shaker_sort(num_list)
            end_time = time()

        case AlgorithmTypes.BUBBLE_SORT:
            used_algorithm_type = "Bubble Sort"
            start_time = time()
            bubble_sort(num_list)
            end_time = time()

        case AlgorithmTypes.SOOTAGE_SORT:
            used_algorithm_type = "Sootage Sort"
            start_time = time()
            sootage_sort(num_list, 0, len(num_list) - 1)
            end_time = time()

        case AlgorithmTypes.BOZO_SORT:
            used_algorithm_type = "Bozo Sort"
            start_time = time()
            bozo_sort(num_list)
            end_time = time()

        case AlgorithmTypes.BOGO_SORT:
            used_algorithm_type = "Bogo Sort"
            start_time = time()
            bogo_sort(num_list)
            end_time = time()

        case _:
            print("The 'selected_algorithm' variable has a problem. Aborting.")
            return

    #print("[" + ", ".join(str(x) for x in num_list) + "]") # To see the list after sorting

    if not is_sorted(num_list):
        print("The sorting algorithm ran but the list is not fully sorted.")
        return

    print(str(len(num_list)) + " random integers has been sorted in " + str((end_time - start_time) * 1000) + " milliseconds using " + used_algorithm_type + ".")
    print()

if __name__ == "__main__":
    main()
