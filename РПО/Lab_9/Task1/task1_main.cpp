#include <iostream>
#include <windows.h>
#include "task1_array_functions.h"

using namespace std;

int main() {
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);

    const int N = 10;
    int arr[N];

    fillArray(arr, N);

    cout << "Массив: ";
    printArray(arr, N);

    cout << "Максимум: " << findMax(arr, N) << endl;
    cout << "Минимум: " << findMin(arr, N) << endl;
    cout << "Среднее: " << average(arr, N) << endl;

    return 0;
}
