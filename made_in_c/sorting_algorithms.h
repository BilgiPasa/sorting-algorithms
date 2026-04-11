#pragma once
#include <stdbool.h>

void print_arr(const int num_arr[], int length);
bool is_sorted(const int num_arr[], int length);
void swap(int *a, int *b);
int compare(const void *elem1, const void *elem2);
int merge_sort(int num_arr[], int length);
void merge_sort_range(int num_arr[], int temp[], int low, int high);
void merge(int num_arr[], int temp[], int low, int mid, int high);
void insertion_sort(int num_arr[], int length);
void selection_sort(int arr[], int length);
int index_of_min(const int num_arr[], int length, int start);
void gnome_sort(int num_arr[], int length);
void bubble_sort(int num_arr[], int length);
void bozo_sort(int num_arr[], int length);
void bogo_sort(int num_arr[], int length);
void fisher_yates_shuffle(int num_arr[], int length);
