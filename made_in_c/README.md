Use this command to compile the C code:
    gcc -std=c23 -Ofast -Wall -Wextra -Wpedantic -o main main.c sorting_algorithms.c

Use this command to run the C code:
    ./main

Use gcc to run the C code. So make sure that you have gcc installed.

I have made the flag arrangement according to gcc manual (man gcc).

(bartu-g, if you use the math.h library in the C code, add the "-lm" flag wherever you want in the compile command)
