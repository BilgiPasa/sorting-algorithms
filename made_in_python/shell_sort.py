from random import randint
from time import time

the_list = [0] * 12345678

for i in range(len(the_list)): # Python's integer is 64 bit. Becuz of that I made the randomizer like this.
    the_list[i] = randint(-2147483648, 2147483647 - 1) # -1 becuz the endpoint is included

def sort(number_list):
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

start_time: float = time()
sort(the_list)
end_time: float = time()
#print("[" + ", ".join(str(x) for x in the_list) + "]") # To see the array
print((str)(len(the_list)) + " integers sorted in " + (str)((end_time - start_time) * 1000) + " milliseconds.")
