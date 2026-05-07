// Задание 2. Основной модуль — main()
#include <iostream>
#include <windows.h>
#include "task2_io_module.h"

using namespace std;

int main() {
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);

    printFactorial(5);
    printFactorial(10);

    printGCD(12, 8);
    printGCD(100, 75);

    printLCM(4, 6);
    printLCM(12, 18);

    return 0;
}
