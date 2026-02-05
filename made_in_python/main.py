from enum import IntEnum
from random import randint
from time import time
import sorting_algorithms

class AlgorithmTypes(IntEnum):
    BUILT_IN = 0
    QUICK_SORT = 1
    MERGE_SORT = 2
    SHELL_SORT = 3
    INSERTSION_SORT = 4
    SELECTION_SORT = 5
    GNOME_SORT = 6
    COCKTAIL_SHAKER_SORT = 7
    BUBBLE_SORT = 8
    SOOTAGE_SORT = 9
    BOZO_SORT = 10
    BOGO_SORT = 11

class Main:
    def main():
        algorithm_type: AlgorithmTypes
        print("\nSorting algorithms (from slowest to fastest)")
        print("1) Quick Sort")
        print("2) Merge Sort")
        print("3) Shell Sort")
        print("4) Insertsion Sort")
        print("5) Selection Sort")
        print("6) Gnome Sort")
        print("7) Cocktail Shaker Sort")
        print("8) Bubble Sort")
        print("9) Sootage Sort")
        print("10) Bozo Sort")
        print("11) Bogo Sort")

        try:
            selected_algorithm: int = int(input("Select an algorithm: "))
        except:
            print("Couldn't understand the input. Aborting.")
            return

        if selected_algorithm == AlgorithmTypes.BUILT_IN:
            algorithm_type = AlgorithmTypes.BUILT_IN
        elif selected_algorithm == AlgorithmTypes.QUICK_SORT:
            algorithm_type = AlgorithmTypes.QUICK_SORT
        elif selected_algorithm == AlgorithmTypes.MERGE_SORT:
            algorithm_type = AlgorithmTypes.MERGE_SORT
        elif selected_algorithm == AlgorithmTypes.SHELL_SORT:
            algorithm_type = AlgorithmTypes.SHELL_SORT
        elif selected_algorithm == AlgorithmTypes.INSERTSION_SORT:
            algorithm_type = AlgorithmTypes.INSERTSION_SORT
        elif selected_algorithm == AlgorithmTypes.SELECTION_SORT:
            algorithm_type = AlgorithmTypes.SELECTION_SORT
        elif selected_algorithm == AlgorithmTypes.GNOME_SORT:
            algorithm_type = AlgorithmTypes.GNOME_SORT
        elif selected_algorithm == AlgorithmTypes.COCKTAIL_SHAKER_SORT:
            algorithm_type = AlgorithmTypes.COCKTAIL_SHAKER_SORT
        elif selected_algorithm == AlgorithmTypes.BUBBLE_SORT:
            algorithm_type = AlgorithmTypes.BUBBLE_SORT
        elif selected_algorithm == AlgorithmTypes.SOOTAGE_SORT:
            algorithm_type = AlgorithmTypes.SOOTAGE_SORT
        elif selected_algorithm == AlgorithmTypes.BOZO_SORT:
            algorithm_type = AlgorithmTypes.BOZO_SORT
        elif selected_algorithm == AlgorithmTypes.BOGO_SORT:
            algorithm_type = AlgorithmTypes.BOGO_SORT
        else:
            print("Couldn't understand the input. Aborting.")
            return

        match algorithm_type:
            case AlgorithmTypes.BUILT_IN:
                print("Enter the list size (12345678 is recommended): ", end="")

            case AlgorithmTypes.QUICK_SORT | AlgorithmTypes.MERGE_SORT | AlgorithmTypes.SHELL_SORT:
                print("Enter the list size (less than 12345678 is recommended): ", end="")

            case AlgorithmTypes.INSERTSION_SORT | AlgorithmTypes.SELECTION_SORT | AlgorithmTypes.GNOME_SORT | AlgorithmTypes.COCKTAIL_SHAKER_SORT | AlgorithmTypes.BUBBLE_SORT:
                print("Enter the list size (less than 55555 is recommended): ", end="")

            case AlgorithmTypes.SOOTAGE_SORT:
                print("Enter the list size (less than 3223 is recommended): ", end="")

            case AlgorithmTypes.BOZO_SORT | AlgorithmTypes.BOGO_SORT:
                print("Enter the list size (maximum 12 is recommended): ", end="")

            case _:
                print("The algorithm type could not found. Aborting.")
                return

        length: int

        try:
            length = int(input())
        except:
            print("Wrong input. Aborting.")
            return

        try:
            num_list = [0] * length
        except:
            print("The list size cannot be " + str(length) + ". Aborting.")
            return

        print("Starting to randomize the list.")
        MAX_VALUE: int = 2147483647

        for i in range(len(num_list)): # Python's integer is 64 bit. Because of that I made the randomizer like this.
            # Note: the randint function includes both end points.
            num_list[i] = randint(0, MAX_VALUE) # Don't forget to write MAX_VALUE as the endpoint.

        print("The list has randomized.")
        #print("[" + ", ".join(str(x) for x in num_list) + "]") # To see the list before sorting
        start_time: float
        end_time: float
        used_algorithm_type: str
        print("Starting to sort the list.")

        match algorithm_type:
            case AlgorithmTypes.BUILT_IN:
                start_time = time()
                num_list = sorted(num_list)
                end_time = time()
                used_algorithm_type = "Python's built-in sorter"

            case AlgorithmTypes.QUICK_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.quick_sort(num_list, 0, len(num_list) - 1)
                end_time = time()
                used_algorithm_type = "Quick Sort"

            case AlgorithmTypes.MERGE_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.merge_sort(num_list)
                end_time = time()
                used_algorithm_type = "Merge Sort"

            case AlgorithmTypes.SHELL_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.shell_sort(num_list)
                end_time = time()
                used_algorithm_type = "Shell Sort"

            case AlgorithmTypes.INSERTSION_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.insertsion_sort(num_list)
                end_time = time()
                used_algorithm_type = "Insertsion Sort"

            case AlgorithmTypes.SELECTION_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.selection_sort(num_list)
                end_time = time()
                used_algorithm_type = "Selection Sort"

            case AlgorithmTypes.GNOME_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.gnome_sort(num_list)
                end_time = time()
                used_algorithm_type = "Gnome Sort"

            case AlgorithmTypes.COCKTAIL_SHAKER_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.cocktail_shaker_sort(num_list)
                end_time = time()
                used_algorithm_type = "Cocktail Shaker Sort"

            case AlgorithmTypes.BUBBLE_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.bubble_sort(num_list)
                end_time = time()
                used_algorithm_type = "Bubble Sort"

            case AlgorithmTypes.SOOTAGE_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.sootage_sort(num_list, 0, len(num_list) - 1)
                end_time = time()
                used_algorithm_type = "Sootage Sort"

            case AlgorithmTypes.BOZO_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.bozo_sort(num_list)
                end_time = time()
                used_algorithm_type = "Bozo Sort"

            case AlgorithmTypes.BOGO_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.bogo_sort(num_list)
                end_time = time()
                used_algorithm_type = "Bogo Sort"

            case _:
                print("The algorithm type could not found. Aborting.")
                return

        #print("[" + ", ".join(str(x) for x in num_list) + "]") # To see the list after sorting

        if sorting_algorithms.SortingAlgorithms.is_sorted(num_list):
            print((str)(len(num_list)) + " random integers has been sorted in " + (str)((end_time - start_time) * 1000) + " milliseconds using " + used_algorithm_type + ".")
        else:
            print("The sorting algorithm ran but the array is not fully sorted.")

    if __name__ == "__main__":
        main()
