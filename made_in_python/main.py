from enum import Enum
from random import randint
from time import time
import sorting_algorithms

class AlgorithmTypes(Enum):
    BUILT_IN = 0
    BOGO_SORT = 1
    BOZO_SORT = 2
    SOOTAGE_SORT = 3
    BUBBLE_SORT = 4
    COCKTAIL_SHAKER_SORT = 5
    GNOME_SORT = 6
    SELECTION_SORT = 7
    INSERTSION_SORT = 8
    SHELL_SORT = 9
    MERGE_SORT = 10
    QUICK_SORT = 11

class Main:
    def main():
        algorithm_type: AlgorithmTypes
        print("\nSorting algorithms (from slowest to fastest)")
        print("1) Bogo Sort")
        print("2) Bozo Sort")
        print("3) Sootage Sort")
        print("4) Bubble Sort")
        print("5) Cocktail Shaker Sort")
        print("6) Gnome Sort")
        print("7) Selection Sort")
        print("8) Insertsion Sort")
        print("9) Shell Sort")
        print("10) Merge Sort")
        print("11) Quick Sort")
        algorithm_type_selection: str = input("Select an algorithm: ")

        if algorithm_type_selection == "0" or algorithm_type_selection == "Built In" or algorithm_type_selection == "BuiltIn" or algorithm_type_selection == "Built-In":
            algorithm_type = AlgorithmTypes.BUILT_IN
        elif algorithm_type_selection == "1" or algorithm_type_selection == "Bogo Sort" or algorithm_type_selection == "BogoSort":
            algorithm_type = AlgorithmTypes.BOGO_SORT
        elif algorithm_type_selection == "2" or algorithm_type_selection == "Bozo Sort" or algorithm_type_selection == "BozoSort":
            algorithm_type = AlgorithmTypes.BOZO_SORT
        elif algorithm_type_selection == "3" or algorithm_type_selection == "Sootage Sort" or algorithm_type_selection == "SootageSort":
            algorithm_type = AlgorithmTypes.SOOTAGE_SORT
        elif algorithm_type_selection == "4" or algorithm_type_selection == "Bubble Sort" or algorithm_type_selection == "BubbleSort":
            algorithm_type = AlgorithmTypes.BUBBLE_SORT
        elif algorithm_type_selection == "5" or algorithm_type_selection == "Cocktail Shaker Sort" or algorithm_type_selection == "CocktailShaker Sort" or algorithm_type_selection == "CocktailShakerSort" or algorithm_type_selection == "Cocktail Sort" or algorithm_type_selection == "CocktailSort" or algorithm_type_selection == "Shaker Sort" or algorithm_type_selection == "ShakerSort":
            algorithm_type = AlgorithmTypes.COCKTAIL_SHAKER_SORT
        elif algorithm_type_selection == "6" or algorithm_type_selection == "Gnome Sort" or algorithm_type_selection == "GnomeSort":
            algorithm_type = AlgorithmTypes.GNOME_SORT
        elif algorithm_type_selection == "7" or algorithm_type_selection == "Selection Sort" or algorithm_type_selection == "SelectionSort":
            algorithm_type = AlgorithmTypes.SELECTION_SORT
        elif algorithm_type_selection == "8" or algorithm_type_selection == "Insertsion Sort" or algorithm_type_selection == "InsertsionSort":
            algorithm_type = AlgorithmTypes.INSERTSION_SORT
        elif algorithm_type_selection == "9" or algorithm_type_selection == "Shell Sort" or algorithm_type_selection == "ShellSort":
            algorithm_type = AlgorithmTypes.SHELL_SORT
        elif algorithm_type_selection == "10" or algorithm_type_selection == "Merge Sort" or algorithm_type_selection == "MergeSort":
            algorithm_type = AlgorithmTypes.MERGE_SORT
        elif algorithm_type_selection == "11" or algorithm_type_selection == "Quick Sort" or algorithm_type_selection == "QuickSort":
            algorithm_type = AlgorithmTypes.QUICK_SORT
        else:
            print("Couldn't understand the input. Aborting.")
            return

        match algorithm_type:
            case AlgorithmTypes.BOGO_SORT | AlgorithmTypes.BOZO_SORT:
                print("Enter the list size (maximum 12 is recommended): ", end="")

            case AlgorithmTypes.SOOTAGE_SORT:
                print("Enter the list size (less than 3223 is recommended): ", end="")

            case AlgorithmTypes.BUBBLE_SORT | AlgorithmTypes.COCKTAIL_SHAKER_SORT | AlgorithmTypes.GNOME_SORT | AlgorithmTypes.SELECTION_SORT | AlgorithmTypes.INSERTSION_SORT:
                print("Enter the list size (less than 55555 is recommended): ", end="")

            case AlgorithmTypes.SHELL_SORT | AlgorithmTypes.MERGE_SORT | AlgorithmTypes.QUICK_SORT:
                print("Enter the list size (less than 12345678 is recommended): ", end="")

            case AlgorithmTypes.BUILT_IN:
                print("Enter the list size (12345678 is recommended): ", end="")

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
            number_list = [0] * length
        except:
            print("The list size cannot be " + str(length) + ". Aborting.")
            return

        print("Starting to randomize the list.")
        max_value_minus_one: int = 2147483647 - 1

        for i in range(len(number_list)): # Python's integer is 64 bit. Because of that I made the randomizer like this.
            # Note: the randint function includes both end points.
            number_list[i] = randint(0, max_value_minus_one) # Write this as the endpoint: max_value_minus_one

        print("The list has randomized.")
        #print("[" + ", ".join(str(x) for x in number_list) + "]") # To see the list before sorting
        start_time: float
        end_time: float
        used_algorithm_type: str
        print("Starting to sort the list.")

        match algorithm_type:
            case AlgorithmTypes.BUILT_IN:
                start_time = time()
                number_list = sorted(number_list)
                end_time = time()
                used_algorithm_type = "Python's built-in sorter"

            case AlgorithmTypes.BOGO_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.bogo_sort(number_list)
                end_time = time()
                used_algorithm_type = "Bogo Sort"

            case AlgorithmTypes.BOZO_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.bozo_sort(number_list)
                end_time = time()
                used_algorithm_type = "Bozo Sort"

            case AlgorithmTypes.SOOTAGE_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.sootage_sort(number_list, 0, len(number_list) - 1)
                end_time = time()
                used_algorithm_type = "Sootage Sort"

            case AlgorithmTypes.BUBBLE_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.bubble_sort(number_list)
                end_time = time()
                used_algorithm_type = "Bubble Sort"

            case AlgorithmTypes.COCKTAIL_SHAKER_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.cocktail_shaker_sort(number_list)
                end_time = time()
                used_algorithm_type = "Cocktail Shaker Sort"

            case AlgorithmTypes.GNOME_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.gnome_sort(number_list)
                end_time = time()
                used_algorithm_type = "Gnome Sort"

            case AlgorithmTypes.SELECTION_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.selection_sort(number_list)
                end_time = time()
                used_algorithm_type = "Selection Sort"

            case AlgorithmTypes.INSERTSION_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.insertsion_sort(number_list)
                end_time = time()
                used_algorithm_type = "Insertsion Sort"

            case AlgorithmTypes.SHELL_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.shell_sort(number_list)
                end_time = time()
                used_algorithm_type = "Shell Sort"

            case AlgorithmTypes.MERGE_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.merge_sort(number_list)
                end_time = time()
                used_algorithm_type = "Merge Sort"

            case AlgorithmTypes.QUICK_SORT:
                start_time = time()
                sorting_algorithms.SortingAlgorithms.quick_sort(number_list, 0, len(number_list) - 1)
                end_time = time()
                used_algorithm_type = "Quick Sort"

            case _:
                print("The algorithm type could not found. Aborting.")
                return

        #print("[" + ", ".join(str(x) for x in number_list) + "]") # To see the list after sorting

        if sorting_algorithms.SortingAlgorithms.is_sorted(number_list):
            print((str)(len(number_list)) + " random integers has been sorted in " + (str)((end_time - start_time) * 1000) + " milliseconds using " + used_algorithm_type + ".")
        else:
            print("The sorting algorithm ran but the array is not fully sorted.")

    if __name__ == "__main__":
        main()
