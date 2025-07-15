from random import randint
from time import time

the_list = [0] * 120000

for i in range(len(the_list)): # Python's integer is 64 bit. Becuz of that I made the randomizer like this.
    the_list[i] = randint(-2147483648, 2147483647 - 1) # -1 becuz the endpoint is included

def sort(number_list, start: int, end: int):
    if start == end:
        return

    if number_list[start] > number_list[end]:
        number_list[start], number_list[end] = number_list[end], number_list[start] # Swapping elements

    if end - start > 1: # This means if (list size > 2)
        one_third: int = (end - start + 1) // 3
        sort(number_list, start, end - one_third)
        sort(number_list, start + one_third, end)
        sort(number_list, start, end - one_third)

start_time: float = time()
sort(the_list, 0, len(the_list) - 1)
end_time: float = time()
#print("[" + ", ".join(str(x) for x in the_list) + "]") # To see the array
print((str)(len(the_list)) + " integers sorted in " + (str)((end_time - start_time) * 1000) + " milliseconds.")
