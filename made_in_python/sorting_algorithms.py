from random import randint, shuffle
import main

class SortingAlgorithms:
    def is_sorted(number_list) -> bool: # To check if the array is sorted
        for i in range(1, len(number_list)):
            if number_list[i - 1] > number_list[i]:
                return False

        return True

    # The algorithms are listed from the fastest to the slowest according to my tests.

    def quick_sort(number_list, start: int, end: int):
        if start >= end:
            return

        pivot: int = SortingAlgorithms.move_elements_and_return_pivot(number_list, start, end)
        SortingAlgorithms.quick_sort(number_list, start, pivot - 1)
        SortingAlgorithms.quick_sort(number_list, pivot + 1, end)

    def move_elements_and_return_pivot(number_list, start: int, end: int) -> int: # This is for Quick Sort
        i: int = start - 1

        for j in range(start, end): # Initial pivot is the last element of the list
            # The program moves the elements that are smaller than the pivot to the left
            if number_list[j] < number_list[end]:
                i += 1
                number_list[i], number_list[j] = number_list[j], number_list[i] # Swapping elements

        i += 1
        number_list[i], number_list[end] = number_list[end], number_list[i] # Swapping elements
        return i # Swapped the initial pivot with the new pivot and returning the new pivot

    def merge_sort(number_list):
        if len(number_list) < 2:
            return

        middle: int = len(number_list) // 2
        i: int
        left_list = [0] * middle
        right_list = [0] * (len(number_list) - middle)

        for i in range(middle):
            left_list[i] = number_list[i]

        for i in range(middle, len(number_list)):
            right_list[i - middle] = number_list[i]

        SortingAlgorithms.merge_sort(left_list)
        SortingAlgorithms.merge_sort(right_list)
        SortingAlgorithms.merge(number_list, left_list, right_list)

    def merge(number_list, left_list, right_list): # This is for Merge Sort
        j: int = 0
        k: int = 0

        for i in range(len(number_list)):
            if j >= len(left_list):
                number_list[i] = right_list[k]
                k += 1
            elif k >= len(right_list):
                number_list[i] = left_list[j]
                j += 1
            else:
                if left_list[j] < right_list[k]:
                    number_list[i] = left_list[j]
                    j += 1
                else:
                    number_list[i] = right_list[k]
                    k += 1

    def shell_sort(number_list):
        interval: int = len(number_list) // 2
        temp: int
        j: int

        while interval > 0:
            for i in range(interval, len(number_list)):
                temp = number_list[i]
                j = i

                while j >= interval and number_list[j - interval] > temp:
                    number_list[j] = number_list[j - interval]
                    j -= interval

                number_list[j] = temp
            interval = interval // 2

    def insertsion_sort(number_list):
        """ In Insertsion Sort; the program checks at the list multiple times part by part as first 2
        elements, first 3 elements, first 4 ... and all of the elements. In each checking, the program goes
        through each part starting from the second to last element of the part and goes to the first element.
        If the element that the program is checking is bigger than the last element of the part, it moves the
        last element of the part in front of the element that the program is checking. The sorting process ends
        when all of the elements are checked. """

        temp: int
        j: int

        for i in range(1, len(number_list)):
            temp = number_list[i]
            j = i - 1

            while j >= 0 and number_list[j] > temp:
                number_list[j + 1] = number_list[j]
                j -= 1

            number_list[j + 1] = temp

    def selection_sort(number_list):
        """ In Selection Sort, the program goes through the list and looks for the smallest element. When the
        list ends, it swaps the smallest element with the first element. Then it goes through the list again
        and looks for the second smallest element. When the list ends, it swaps the second smallest element
        with the second element and the process goes on like that until the list is sorted. """

        length_minus_one: int = len(number_list) - 1
        j: int

        for i in range(length_minus_one):
            j = SortingAlgorithms.index_of_min(number_list, len(number_list), i)
            number_list[i], number_list[j] = number_list[j], number_list[i] # Swapping elements

    def index_of_min(number_list, length: int, start: int): # This is for Selection Sort
        min: int = start

        for i in range(start, length):
            if number_list[min] > number_list[i]:
                min = i

        return min

    def gnome_sort(number_list):
        i: int = 1

        while i < len(number_list):
            if i > 0 and number_list[i - 1] > number_list[i]:
                number_list[i - 1], number_list[i] = number_list[i], number_list[i - 1] # Swapping elements
                i -= 1
            else:
                i += 1

    def cocktail_shaker_sort(number_list):
        """ You can think Cocktail Shaker Sort as a double sided Bubble Sort. Cocktail Shaker Sort starts from
        the left side and moves to right like Bubble Sort but when it reaches the end, it moves to left. So the
        Cocktail Shaker Sort moves back and forth and swaps the elements if the left element is bigger than the
        right element. While swapping the elements, the smaller elements move to the left side and the bigger
        elements move to the right side. """

        start: int = 0
        end: int = len(number_list) - 1
        i: int

        while end - start > 1:
            for i in range(start, end):
                if number_list[i] > number_list[i + 1]:
                    number_list[i], number_list[i + 1] = number_list[i + 1], number_list[i] # Swapping elements

            end -= 1

            for i in range(end, start, -1):
                if number_list[i - 1] > number_list[i]:
                    number_list[i - 1], number_list[i] = number_list[i], number_list[i - 1] # Swapping elements

            start += 1

    def bubble_sort(number_list):
        """ In Bubble Sort, the program goes through the list and checks the elements and the elements next
        to it. If the left element is bigger than the right element, the program swaps the elements. When the
        list ends, if the list is not sorted, the program repeats this process until the list is sorted. """

        length: int = len(number_list)
        swapped: bool

        while True:
            swapped = False

            for i in range(1, len(length)):
                if number_list[i - 1] > number_list[i]:
                    number_list[i - 1], number_list[i] = number_list[i], number_list[i - 1] # Swapping elements
                    swapped = True

            length -= 1

            if not swapped:
                break

    def sootage_sort(number_list, start: int, end: int):
        if start == end:
            return

        if number_list[start] > number_list[end]:
            number_list[start], number_list[end] = number_list[end], number_list[start] # Swapping elements

        if end - start > 1: # This means if (list size > 2)
            one_third: int = (end - start + 1) // 3
            SortingAlgorithms.sootage_sort(number_list, start, end - one_third)
            SortingAlgorithms.sootage_sort(number_list, start + one_third, end)
            SortingAlgorithms.sootage_sort(number_list, start, end - one_third)

    def bozo_sort(number_list):
        """ In Bozo Sort; firstly, the program checks if the list is sorted. If not, it selects two random
        items and swaps them. Then, it checks again if the list is sorted. The program repeates this process
        until the list is sorted. """

        b: bool = SortingAlgorithms.is_sorted(number_list)
        length_minus_one: int = len(number_list) - 1
        index1: int
        index2: int

        while not b:
            while True:
                index1 = randint(0, length_minus_one)
                index2 = randint(0, length_minus_one)

                if index1 != index2:
                    break

            number_list[index1], number_list[index2] = number_list[index2], number_list[index1] # Swapping elements
            b = SortingAlgorithms.is_sorted(number_list)

    def bogo_sort(number_list):
        """ In Bogo Sort; firstly, the program checks if the list is sorted. If not, it shuffels the list and
        checks again if the list is sorted. The program repeates this process until the list is sorted. """

        b: bool = SortingAlgorithms.is_sorted(number_list)

        while not b:
            shuffle(number_list)
            b = SortingAlgorithms.is_sorted(number_list)

    if __name__ == "__main__":
        main.Main.main()
