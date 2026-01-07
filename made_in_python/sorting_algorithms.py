from random import shuffle, randint
import main

class SortingAlgorithms:
    # The algorithms are listed from the slowest to the fastest.

    def bogo_sort(number_list):
        """ In Bogo Sort; firstly, the program checks if the list is sorted. If not, it shuffels the list and
        checks again if the list is sorted. The program repeates this process until the list is sorted. """

        i: int
        b: bool = True

        for i in range(1, len(number_list)): # Cheking if the list is sorted
            if number_list[i - 1] > number_list[i]:
                b = False
                break

        while not b:
            b = True
            shuffle(number_list)

            for i in range(1, len(number_list)): # Cheking if the list is sorted
                if number_list[i - 1] > number_list[i]:
                    b = False
                    break

    def bozo_sort(number_list):
        """ In Bozo Sort; firstly, the program checks if the list is sorted. If not, it selects two random
        items and swaps them. Then, it checks again if the list is sorted. The program repeates this process
        until the list is sorted. """

        i: int
        b: bool = True

        for i in range(1, len(number_list)): # Cheking if the list is sorted
            if number_list[i - 1] > number_list[i]:
                b = False
                break

        if b:
            return

        index1: int
        index2: int

        while not b:
            b = True

            while True:
                index1 = randint(0, len(number_list) - 1)
                index2 = randint(0, len(number_list) - 1)

                if index1 != index2:
                    break

            number_list[index1], number_list[index2] = number_list[index2], number_list[index1] # Swapping elements

            for i in range(1, len(number_list)): # Cheking if the list is sorted
                if number_list[i - 1] > number_list[i]:
                    b = False
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

    def bubble_sort(number_list):
        """ In Bubble Sort, the program goes through the list and checks the elements and the elements next
        to it. If the left element is bigger than the right element, the program swaps the elements. When the
        list ends, if the list is not sorted, the program repeats this process until the list is sorted. """

        i: int
        j: int

        while True:
            i = 0

            for j in range(1, len(number_list)):
                if number_list[j - 1] > number_list[j]:
                    number_list[j - 1], number_list[j] = number_list[j], number_list[j - 1] # Swapping elements
                    i += 1

            if i == 0:
                break

    def gnome_sort(number_list):
        """ In Gnome Sort, the program goes through the list from the start and checks the elements and the
        elements next to it. If the left element is bigger than the right element, the program swaps the
        elements and starts to go backwards. While going backwards, if the left element is bigger than the
        right next element, the program swaps the elements. When the program is at the start again, it starts
        to go forward and this process repeates until the program is at the end of the list. """

        i: int = 1
        forward: bool = True

        while True:
            while forward:
                if i == len(number_list):
                    return

                if number_list[i - 1] <= number_list[i]:
                    i += 1
                else:
                    number_list[i - 1], number_list[i] = number_list[i], number_list[i - 1]
                    forward = False
                    break

            while not forward:
                if i == 1:
                    forward = True
                    break

                if number_list[i - 1] > number_list[i]:
                    number_list[i - 1], number_list[i] = number_list[i], number_list[i - 1]

                i -= 1

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
                    number_list[i], number_list[i + 1] = number_list[i + 1], number_list[i]

            end -= 1

            for i in range(end, start, -1):
                if number_list[i - 1] > number_list[i]:
                    number_list[i - 1], number_list[i] = number_list[i], number_list[i - 1]

            start += 1

    def insertsion_sort(number_list):
        """ In Insertsion Sort; the program checks at the list multiple times part by part as first 2
        elements, first 3 elements, first 4 ... and all of the elements. In each checking, the program goes
        through each part starting from the second to last element of the part and goes to the first element.
        If the element that the program is checking is bigger than the last element of the part, it moves the
        last element of the part in front of the element that the program is checking. The sorting process ends
        when all of the elements are checked. """

        temp: int

        for i in range(1, len(number_list)):
            for j in range(i - 1, -1, -1): # j starts with i - 1 and ends with 0 (included) while going back 1 step
                if number_list[i] < number_list[j]:
                    temp = number_list[i]

                    for k in range(i, j, -1):
                        number_list[k] = number_list[k - 1]

                    number_list[j] = temp

    def selection_sort(number_list):
        """ In Selection Sort, the program goes through the list and looks for the smallest element. When the
        list ends, it swaps the smallest element with the first element. Then it goes through the list again
        and looks for the second smallest element. When the list ends, it swaps the second smallest element
        with the second element and the process goes on like that until the list is sorted. """

        smallest: int

        for i in range(len(number_list) - 1):
            smallest = i

            for j in range(i, len(number_list)):
                if number_list[smallest] > number_list[j]:
                    smallest = j

            number_list[i], number_list[smallest] = number_list[smallest], number_list[i] # Swapping elements

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
        i: int = 0
        j: int = 0
        k: int = 0

        while i < len(left_list) and j < len(right_list):
            if left_list[i] > right_list[j]:
                number_list[k] = right_list[j]
                k += 1
                j += 1
            else:
                number_list[k] = left_list[i]
                k += 1
                i += 1

        while i < len(left_list):
            number_list[k] = left_list[i]
            k += 1
            i += 1

        while j < len(right_list):
            number_list[k] = right_list[j]
            k += 1
            j += 1

    def quick_sort(number_list, start: int, end: int):
        if start >= end:
            return

        pivot: int = SortingAlgorithms.move_elements_and_return_pivot(number_list, start, end)
        SortingAlgorithms.quick_sort(number_list, start, pivot - 1)
        SortingAlgorithms.quick_sort(number_list, pivot + 1, end)

    def move_elements_and_return_pivot(number_list, start: int, end: int): # This is for Quick Sort
        i: int = start - 1

        for j in range(start, end): # Initial pivot is the last element of the list
            # The program moves the elements that are smaller than the pivot to the left
            if number_list[j] < number_list[end]:
                i += 1
                number_list[i], number_list[j] = number_list[j], number_list[i] # Swapping elements

        i += 1
        number_list[i], number_list[end] = number_list[end], number_list[i] # Swapping elements
        return i # Swapped the initial pivot with the new pivot and returning the new pivot

    if __name__ == "__main__":
        main.Main.main()
