// Задание 3. Тестирование функций математического модуля
#include <iostream>
#include <windows.h>
#include "task2_math_module.h"

using namespace std;

int testsPassed = 0;
int testsFailed = 0;

void check(const char* name, bool condition) {
    if (condition) {
        cout << "[OK] " << name << endl;
        testsPassed++;
    } else {
        cout << "[FAIL] " << name << endl;
        testsFailed++;
    }
}

int main() {
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);

    // Тесты факториала
    check("factorial(0) == 1", factorial(0) == 1);
    check("factorial(1) == 1", factorial(1) == 1);
    check("factorial(5) == 120", factorial(5) == 120);
    check("factorial(10) == 3628800", factorial(10) == 3628800);

    // Тесты НОД
    check("gcd(12, 8) == 4", gcd(12, 8) == 4);
    check("gcd(100, 75) == 25", gcd(100, 75) == 25);
    check("gcd(7, 3) == 1", gcd(7, 3) == 1);
    check("gcd(0, 5) == 5", gcd(0, 5) == 5);

    // Тесты НОК
    check("lcm(4, 6) == 12", lcm(4, 6) == 12);
    check("lcm(12, 18) == 36", lcm(12, 18) == 36);
    check("lcm(7, 3) == 21", lcm(7, 3) == 21);

    cout << endl;
    cout << "Пройдено: " << testsPassed << endl;
    cout << "Провалено: " << testsFailed << endl;

    return 0;
}
