from random import randint
from time import time

the_list = [0] * 120000

for i in range(len(the_list)): # Python's integer is 64 bit. Becuz of that I made the randomizer like this.
    the_list[i] = randint(-2147483648, 2147483647 - 1) # -1 becuz the endpoint is included

def sort(number_list):
    temp: int

    for i in range(1, len(number_list)):
        for j in range(i - 1, -1, -1): # j starts with i - 1 and ends with 0 (included) while going back 1 step
            if number_list[i] < number_list[j]:
                temp = number_list[i]

                for k in range(i, j, -1):
                    number_list[k] = number_list[k - 1]

                number_list[j] = temp

start_time: float = time()
sort(the_list)
end_time: float = time()
#print("[" + ", ".join(str(x) for x in the_list) + "]") # To see the array
print((str)(len(the_list)) + " integers sorted in " + (str)((end_time - start_time) * 1000) + " milliseconds.")
