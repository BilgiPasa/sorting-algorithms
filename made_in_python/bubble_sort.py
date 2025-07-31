from random import randint
from time import time

the_list = [0] * 55555

for i in range(len(the_list)): # Python's integer is 64 bit. Becuz of that I made the randomizer like this.
    the_list[i] = randint(-2147483648, 2147483647 - 1) # -1 becuz the endpoint is included

def sort(number_list):
    """ In Bubble Sort, the program goes through the array and checks the elements and the elements next to
    it. If the left element that program is checking is bigger than the right next element, the program
    swaps the elements. When the array ends, if the array is not sorted, the program repeats this process
    until the array is sorted. """

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

start_time: float = time()
sort(the_list)
end_time: float = time()
#print("[" + ", ".join(str(x) for x in the_list) + "]") # To see the array
print((str)(len(the_list)) + " integers sorted in " + (str)((end_time - start_time) * 1000) + " milliseconds.")
