from random import randint
from time import time

the_list = [0] * 120000

for i in range(len(the_list)): # Python's integer is 64 bit. Becuz of that I made the randomizer like this.
    the_list[i] = randint(-2147483648, 2147483647 - 1) # -1 becuz the endpoint is included

def sort(number_list):
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

start_time: float = time()
sort(the_list)
end_time: float = time()
#print("[" + ", ".join(str(x) for x in the_list) + "]") # To see the array
print((str)(len(the_list)) + " integers sorted in " + (str)((end_time - start_time) * 1000) + " milliseconds.")
