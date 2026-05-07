// Задание 1. Модуль B — использование глобальной переменной из другого модуля
#include <iostream>
#include <windows.h>

using namespace std;

extern int globalCounter;  // ссылка на переменную из module_a.cpp

int main() {
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);

    cout << "Значение globalCounter: " << globalCounter << endl;

    globalCounter += 50;
    cout << "После изменения: " << globalCounter << endl;

    return 0;
}
