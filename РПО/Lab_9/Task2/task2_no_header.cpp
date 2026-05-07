// Задание 2. Компиляция без заголовочного файла — анализ ошибок
// Если скомпилировать этот файл без подключения заголовочного файла,
// компилятор выдаст ошибки:
//   error C3861: 'fillArray': identifier not found
//   error C3861: 'printArray': identifier not found
//   error C3861: 'findMax': identifier not found
// Это происходит потому, что компилятор не видит объявлений функций.
// Для исправления нужно подключить заголовочный файл: #include "task1_array_functions.h"

#include <iostream>
#include <windows.h>
using namespace std;

// Закомментировано для демонстрации ошибки:
// #include "task1_array_functions.h"

int main() {
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);

    const int N = 5;
    int arr[N];

    fillArray(arr, N);      // Ошибка: функция не объявлена
    printArray(arr, N);     // Ошибка: функция не объявлена
    cout << "Макс: " << findMax(arr, N) << endl;  // Ошибка: функция не объявлена

    return 0;
}
