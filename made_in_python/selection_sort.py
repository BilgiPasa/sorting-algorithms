from random import randint
from time import time

the_list = [0] * 55555

for i in range(len(the_list)): # Python's integer is 64 bit. Becuz of that I made the randomizer like this.
    the_list[i] = randint(-2147483648, 2147483647 - 1) # -1 becuz the endpoint is included

def sort(number_list):
    """ In Selection Sort, the program goes through the array and looks for the smallest element. When the
    array ends, it swaps the smallest element with the first element. Then it goes through the array again and
    looks for the second smallest element. When the array ends, it swaps the second smallest element with the
    second element and it goes on like that until the array is sorted. """

    smallest: int

    for i in range(len(number_list) - 1):
        smallest = i

        for j in range(i, len(number_list)):
            if number_list[smallest] > number_list[j]:
                smallest = j

        number_list[i], number_list[smallest] = number_list[smallest], number_list[i] # Swapping elements

start_time: float = time()
sort(the_list)
end_time: float = time()
#print("[" + ", ".join(str(x) for x in the_list) + "]") # To see the array
print((str)(len(the_list)) + " integers sorted in " + (str)((end_time - start_time) * 1000) + " milliseconds.")
