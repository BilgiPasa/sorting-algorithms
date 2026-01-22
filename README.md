# sorting-algorithms

These are sorting algorithms in different programming languages.

This repository is focused on non-negative integer sorting algorithms to keep it simple. (Specifically, signed 32 bit integers but I only use the non-negative integers.)

Implemented sorting algorithms (from fastest to slowest*): Quick Sort, Merge Sort, Shell Sort, Selection Sort, Insertsion Sort, Gnome Sort, Cocktail Shaker Sort, Bubble Sort, Sootage Sort, Bozo Sort, Bogo Sort.

*According to my tests when I test with Java. (If you compare the sorting algorithms' speed in different languages, you might get a different result. Also, I didn't compare any language's built in sorter in this list.)

Implemented languages are C, C#, Java and Python.

(C implementation is not fully done yet.)

C is implemented and mostly maintained by bartu-g. Thank you for contributing.

Speed comparison of the languages (from fastest to slowest**): Java (25), C (GCC 15), C# (.Net 10), Python (3.14).

**According to my tests when I use Selection Sort. (I used VS Code for testing. If you test yourself, you might get a different result.)

I DID NOT copy-pasted any code from any Generative AI prompt. I wrote the code of the algorithms that I maintain myself. I learned these algorithms from websites (for example geeksforgeeks) and videos (for example Bro Code and udiprod channels' videos). Also, I don't like using Generative AI and I don't recommend using it.

---

The code files' locations:

the C files are in the made_in_c folder,

the C# files are in the MadeInC#/MadeInCSharp folder,

the Java files are in the MadeInJava/src folder,

the Python files are in the made_in_python folder.

(Use backward slashes if you use Windows file explorer.)

---

I'm not planning to implement the Pigeonhole Sort algorithm because I don't want to come across memory problems due to making the array size very huge (like making the length as 2^31).

I'm not planning to implement the Bucket Sort algorithm because I want to use just arrays in this repo. I don't want to use array lists or linked lists in this repo.

---

TODO:

* Try to implement the Radix Sort and the Heap Sort algorithms in C#, Java and Python.

---

README written by Bilgi Paşa.
