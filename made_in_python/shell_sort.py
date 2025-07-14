from random import randint
from time import time

the_list = [0] * 120000

for i in range(len(the_list)): # Python's integer is 64 bit. Becuz of that I made the randomizer like this.
    the_list[i] = randint(-2147483648, 2147483647 - 1) # -1 becuz the endpoint is included

def sort(number_list):
    gap: int = len(number_list) // 2
    temp: int
    j: int

    while gap > 0:
        for i in range(gap, len(number_list)):
            temp = number_list[i]
            j = i

            while j >= gap and number_list[j - gap] > temp:
                number_list[j] = number_list[j - gap]
                j -= gap

            number_list[j] = temp
        gap = gap // 2

start_time: float = time()
sort(the_list)
end_time: float = time()
#print("[" + ", ".join(str(x) for x in the_list) + "]") # To see the array
print((str)(len(the_list)) + " integers sorted in " + (str)((end_time - start_time) * 1000) + " milliseconds.")
