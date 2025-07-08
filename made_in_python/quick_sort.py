from random import randint
from time import time

the_list = [0] * 10000

for i in range(0, len(the_list)): # Python's integer is 64 bit. Becuz of that I made the randomizer like this.
    the_list[i] = randint(-2147483648, 2147483647 - 1) # -1 becuz the endpoint is included

def partition(number_list, start: int, end: int):
    i: int = start - 1

    for j in range(start, end):
        if number_list[j] < number_list[end]:
            i += 1
            number_list[i], number_list[j] = number_list[j], number_list[i] # Swapping elements

    i += 1
    number_list[i], number_list[end] = number_list[end], number_list[i] # Swapping elements
    return i

def sort(number_list, start: int, end: int):
    if end <= start:
        return

    pivot: int = partition(number_list, start, end)
    sort(number_list, start, pivot - 1)
    sort(number_list, pivot + 1, end)

start_time: float = time()
sort(the_list, 0, len(the_list) - 1)
end_time: float = time()
#print("[" + ", ".join(str(x) for x in the_list) + "]") # To see the array
print((str)(len(the_list)) + " integers sorted in " + (str)((end_time - start_time) * 1000) + " milliseconds.")
