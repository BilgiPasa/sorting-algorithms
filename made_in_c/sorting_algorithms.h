#pragma once
#include <stdbool.h>

void print_array(const int number_array[], int length);
bool is_sorted(const int number_array[], int length);
void swap(int *a, int *b);
void bubble_sort(int number_array[], int length);
void gnome_sort(int number_array[], int length);
void insertion_sort(int number_array[], int length);
void selection_sort(int arr[], int length);
int index_of_min(const int number_array[], int length, int start);
