#include <iostream>
#include <cstdlib>
#include <ctime>
#include "task1_array_functions.h"

using namespace std;

void fillArray(int arr[], int size) {
    srand(time(0));
    for (int i = 0; i < size; i++)
        arr[i] = rand() % 100;
}

void printArray(int arr[], int size) {
    for (int i = 0; i < size; i++)
        cout << arr[i] << " ";
    cout << endl;
}

int findMax(int arr[], int size) {
    int max = arr[0];
    for (int i = 1; i < size; i++)
        if (arr[i] > max) max = arr[i];
    return max;
}

int findMin(int arr[], int size) {
    int min = arr[0];
    for (int i = 1; i < size; i++)
        if (arr[i] < min) min = arr[i];
    return min;
}

double average(int arr[], int size) {
    int sum = 0;
    for (int i = 0; i < size; i++)
        sum += arr[i];
    return (double)sum / size;
}
