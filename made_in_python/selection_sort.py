from random import randint
from time import time

the_list = [0] * 10000

for i in range(0, len(the_list)): # Python's integer is 64 bit. Becuz of that I made the randomizer like this.
    the_list[i] = randint(-2147483648, 2147483647 - 1) # -1 becuz the endpoint is included

def sort(number_list):
    smallest: int

    for i in range(0, len(number_list) - 1):
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
