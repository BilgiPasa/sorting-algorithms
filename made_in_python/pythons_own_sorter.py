from random import randint
from sys import maxsize
from time import time

the_list: int = [0] * 5000

for i in range(0, 5000):
    the_list[i] = randint(-maxsize, maxsize)

start: float = time()
the_list = sorted(the_list)
end: float = time()
#print("[" + ", ".join(str(x) for x in the_list) + "]") # To see the array
print((str)(end - start) + " seconds elapsed to sort")
